
/************************************************
	Lazy Delete Vector

	description : 
	
	the lazy delete vector is a vector. or more to the point,
	it can emulate a vector's behavior. this however is not it's
	purpose, merely a side benefit. The ld_vector is a factory
	design pattern transparent to the user.	Use the ld_vector
	when the ordering of your data is unimportant, but speed is.

	Author : Lari H. Norri
	date started : 10/??/04
	last modified : 07/09/05 (in Beta rev. 1.0)

	Use :	for exact "stl vector" behavior, do not use any of the following
			functions. "remove, or "set_valid".

			for "factory (FAST!!!)" behavior, do not use the following:
			"for loops with array indexing"(use the provided iterator instead),
			"erase", "insert", "collapse_left", or "collapse_right"

			you can mix these behaviors safely, but read the function comments to
			understand the reprucusions. I provide some vector mimicing operations
			for flexibility and easy code integration, however this class is designed
			for superfast random access + adding + deleteing. I do not recommend this
			class if the order of your data is very important to you.

	Licence :	This code is free to use/modify whatever.
				Just mention me as the original author.
	
	Thanks :	A very big THANK YOU goes out to Lee Wood,
				your knowledge and insight have been invaluable 
				during the development of this ADT. I would	also
				like to thank Chris Ragland and Nelson Nievies
				for their input. also Hewlet Packard for your amazing STL.

***********************************************/

#ifndef _LD_VECTOR_H_
#define _LD_VECTOR_H_

#include <memory.h>

// defines an signed/unsigned interger 32 bits in length
// and a boolean value 8 bits in length
#define uInt32 unsigned int
#define Int32 signed int
#define Bool8 bool

template< typename T >
class ld_vector
{
	// how much can you hold vs what your holding.
	uInt32 _capacity, _size, _last;	// last is defined as one past the end
	
	// bit maps	(used for fast searching)
	uInt32 *high_map, hmap_sz; // 1 bit per 32 elements
	uInt32 *low_map, lmap_sz; // 1 bit per element

	// all the data stored by the vector
	T *Data;

	// stores up to date accurate info about this ld_vector
	// NOTE: switch to using "_end" instead of capacity for the iterator class
	struct Arbitrator
	{
		uInt32 *_end; // one past the last item
		uInt32 *lmap; // pointer to the active lowmap (for iteration)
		T *dat;	// data vault access
	};
	Arbitrator arbiter;

	// Macros for enabling, disabling and testing bits in the maps
	#define TEST_MAP_BIT(map, index) (((map)[(index) >> 5u]) & (0x00000001u << ((index) & 31u)))
	// turns on a particular bit in the lowmap, it also enables the highmap bit if neccacary
	#define ENABLE_MAP_BIT(index) \
			{ low_map[(index)>>5u] |= (0x00000001u << ((index) & 31u));\
			if(0xFFFFFFFFu == low_map[(index)>>5u])\
				high_map[((index)>>5u)>>5u] |= (0x00000001u << (((index)>>5u) & 31u));\
			}
	// turns off a particular bit in the lowmap, it also disables the highmap bit if neccacary
	#define DISABLE_MAP_BIT(index) \
			{ low_map[(index)>>5u] &= ~(0x00000001u << ((index) & 31u));\
			if(0xFFFFFFFFu != low_map[(index)>>5u])\
				high_map[((index)>>5u)>>5u] &= ~(0x00000001u << (((index)>>5u) & 31u));\
			}

	// the following macros are used to find an open bit quickly from a 32bit value
	#define _TEST_IF(x, b32) if((x) & ~(b32)) {
	#define _TEST_ELSE(x, b32) } else if((x) & ~(b32)) {
	#define _SET_IF(x, b32, t, f, i) (i) = ((x) & ~(b32)) ? (t) : (f);
	#define _SET_ELSE(x, b32, t, f, i) } else if((x) & ~(b32)) { (i) = (t); } else { (i) = (f); }
	
	// finds an open bit from a 32 bit value
	// btw... yes i know this is a flagrant abuse of macros, 
	// but you really dont want to see this unrolled.
	#define FIND_OPEN_BIT(i, b32) \
		_TEST_IF(0x0000FFFFu, b32)\
			_TEST_IF(0x000000FFu, b32)\
				_TEST_IF(0x0000000Fu, b32)\
					_TEST_IF(0x00000003u, b32)\
						_SET_IF(0x00000001u, b32, 0u, 1u, i)\
					_SET_ELSE(0x00000004u, b32, 2u, 3u, i)\
				_TEST_ELSE(0x00000030u, b32)\
					_SET_IF(0x00000010u, b32, 4u, 5u, i)\
				_SET_ELSE(0x00000040u, b32, 6u, 7u, i)\
			_TEST_ELSE(0x00000F00u, b32)\
				_TEST_IF(0x00000300u, b32)\
					_SET_IF(0x00000100u, b32, 8u, 9u, i)\
				_SET_ELSE(0x00000400u, b32, 10u, 11u, i)\
			_TEST_ELSE(0x00003000u, b32)\
				_SET_IF(0x00001000u, b32, 12u, 13u, i)\
			_SET_ELSE(0x00004000u, b32, 14u, 15u, i)\
		_TEST_ELSE(0x00FF0000u, b32)\
			_TEST_IF(0x000F0000u, b32)\
				_TEST_IF(0x00030000u, b32)\
					_SET_IF(0x00010000u, b32, 16u, 17u, i)\
				_SET_ELSE(0x00040000u, b32, 18u, 19u, i)\
			_TEST_ELSE(0x00300000u, b32)\
				_SET_IF(0x00100000u, b32, 20u, 21u, i)\
			_SET_ELSE(0x00400000u, b32, 22u, 23u, i)\
		_TEST_ELSE(0x0F000000u, b32)\
			_TEST_IF(0x03000000u, b32)\
				_SET_IF(0x01000000u, b32, 24u, 25u, i)\
			_SET_ELSE(0x04000000u, b32, 26u, 27u, i)\
		_TEST_ELSE(0x30000000u, b32)\
			_SET_IF(0x10000000u, b32, 28u, 29u, i)\
		_SET_ELSE(0x40000000u, b32, 30u, 31u, i)

	// this is called by any constructor to initialize the vector
	void _create(void)
	{
		_capacity = _size =		// the vector can hold nothing by default 
		hmap_sz = lmap_sz = 0u;	// both maps start with 0 bits
		high_map = low_map = 0u;	// both maps are safe to delete initially
		Data = 0u;				// clear all data
		_last = 0u;				// the index of the last element + 1
		memset(&arbiter, 0u, sizeof(Arbitrator)); // zero out the arbiter
	}

	// when the vector runs out of memory, this command doubles its capacity
	void _expand(void)
	{
		// double the capacity
		(_capacity) ? _capacity = _capacity << 1u : _capacity = 1u;
		T * d_alloc = new T[_capacity];	// allocate new data array
		for(uInt32 i = 0u; i < _capacity >> 1u; ++i) d_alloc[i] = Data[i]; // copy all data
		delete [] Data; // clear old data
		Data = d_alloc; // point Data in the right direction
		// allocate the low map if neccasary
		if(lmap_sz < (_capacity >> 5u)+1u)
		{
			// increase the size of the low_map
			(lmap_sz) ? lmap_sz = lmap_sz << 1u : lmap_sz = 1u;
			uInt32 * lm = new uInt32[lmap_sz];
			memset(lm, 0u, lmap_sz << 2u); // clear the new array
			if(lmap_sz > 1u) memcpy(lm, low_map, lmap_sz << 1u); // carry over the old values
			delete [] low_map; // remove the old map
			low_map = lm;  // affix the new map
		}
		// allocate the high map if neccasary
		if(hmap_sz < ((_capacity >> 5u) >> 5u)+1u)
		{
			// increase the size of the high_map
			(hmap_sz) ? hmap_sz = hmap_sz << 1u : hmap_sz = 1u;
			uInt32 * hm = new uInt32[hmap_sz];
			memset(hm, 0u, hmap_sz << 2u); // clear the new array
			if(hmap_sz > 1u) memcpy(hm, high_map, hmap_sz << 1u); // carry over the old values
			delete [] high_map; // remove the old map
			high_map = hm;  // affix the new map
		}
		// update the arbiter (this is the only time we need do so)
		arbiter._end = &_last;
		arbiter.dat = Data;
		arbiter.lmap = low_map;
	}

public:

	// define the nested iterator class
	class iterator;
	friend class iterator;

	class iterator
	{
		uInt32 index; // our current index into the ld_vector
		const Arbitrator *envoy; // lets the iter stay informed about it's designated vector

		public :
			
		// creates an iterator with the proper values
		explicit iterator(uInt32 i = 0u, const Arbitrator *a = 0u) : index(i), envoy(a) { }

		T *operator->() const { return &envoy->dat[index]; }
		T &operator*() const { return envoy->dat[index]; }

		Bool8 operator==(const iterator &comp) const 
		{	return index == comp.index;	}
		
		Bool8 operator!=(const iterator &comp) const 
		{	return index != comp.index;	}

		// coverts an iterator directly to it's index
		operator uInt32() const { return index; }
		operator Int32() const { return (Int32)index; }
		// only is false if the iterator is at the end of a vector
		operator Bool8() const { return index < envoy->_cap; } // take into account begin

		iterator &operator++() 
		{ 
			if(index+1u >= (*envoy->_end)+1u) return (*this); // don't iterate after the end 
			while(++index < (*envoy->_end) && !TEST_MAP_BIT(envoy->lmap, index))
				if(!(index & 31u) && 0x00000000u == envoy->lmap[index >> 5u])
					if(index + 32u < (*envoy->_end)) index += 31u; // skip 32 empty items if possible
			return (*this); 
		}

		iterator &operator--() 
		{ 
			if(!index) return (*this); // don't iterate before the begining
			while(--index && !TEST_MAP_BIT(envoy->lmap, index)) // hmmm
				if(index > 31u && !((index-32u) & 31u) && 0x00000000u == envoy->lmap[(index-32u) >> 5u])
					index -= 31u; // skip 32 empty items if possible
			return (*this); 
		}

		iterator operator++(Int32)
		{
			iterator tmp = *this;
			++*this;
			return tmp;
		}

		iterator operator--(Int32)
		{
			iterator tmp = *this;
			--*this;
			return tmp;
		}

		iterator operator+(Int32 mov) const { return iterator(index + mov, envoy); }			
		iterator operator-(Int32 mov) const { return iterator(index - mov, envoy); }
		iterator operator+(uInt32 mov) const { return iterator(index + mov, envoy); }			
		iterator operator-(uInt32 mov) const { return iterator(index - mov, envoy); }
	};

	// constructor + trilogy of evil
	ld_vector(void) { _create(); } // default constructor
	ld_vector(uInt32 count) { _create(); reserve(count); } // this constructor reserves room
	ld_vector(uInt32 count, const T &val) // this reserves and sets all items to "val" 
	{ 
		_create(); reserve(count);
		for(uInt32 i = 0; i < count; ++i) 
		{ Data[i] = val; ENABLE_MAP_BIT(i); }
		_size = count;
	}

	// assigment operator
	ld_vector<T> &operator=(const ld_vector<T> &cpy)
	{
		// don't perform needless copy
		if(this == &cpy) return *this;
		// copy the valid contents of the incomming vector
		clear(); // empty this vector
		// reserve room	to copy to
		if(_capacity < cpy._capacity) reserve(cpy._capacity);
		// copy all valid items
		iterator copy = cpy.begin(), last = cpy.end();
		while(copy != last)
		{
			Data[(uInt32)copy] = cpy.Data[(uInt32)copy];
			ENABLE_MAP_BIT((uInt32)copy);
			++copy;
		}
		// match the sizes & the last item
		_size = cpy._size;
		_last = cpy._last;
		return *this;
	}

	// copy constructor
	ld_vector(const ld_vector<T> &copy) { _create(); *this = copy; }

	// destructor
	~ld_vector(void) { _destroy(); }

	// return an iterator to the front of the ld_vector
	iterator begin() const 
	{ 
		return (_capacity) ? ++iterator(0xFFFFFFFFu, &arbiter) : iterator(0u, &arbiter);
	}
	// return an iterator to one past the end of the ld_vector
	iterator end() const 
	{ 
		return iterator(_last, &arbiter);
	}

	// returns the number of items in the vector
	uInt32 size(void) const { return _size; }
	// returns the capacity of the vector
	uInt32 capacity(void) const { return _capacity; }

	// reserves at least r items in the vector (memory is always reserved in powers of two)
	// capacity	is garunteed to be >= to r
	void reserve(uInt32 r) { while(_capacity < r) _expand(); } // could be optimized

	// return an item from the array
	T &operator[](uInt32 index) { return Data[index]; } 
	// return an item from the array const
	const T &operator[](uInt32 index) const { return Data[index]; } 

	// tells you if a index in the array is in use
	Bool8 is_valid(uInt32 index)
	{
		if(index >= _capacity) return false;
		return (TEST_MAP_BIT(low_map,index)) ? true : false;	
	}

	// forces an index to make itself valid/Invalid
	// making an index Invalid is the same as calling remove on an iterator at the same index.
	void set_valid(uInt32 index, Bool8 valid = true)
	{
		if(valid && !TEST_MAP_BIT(low_map, index))
		{ 
			ENABLE_MAP_BIT(index); ++_size;
			if(index >= _last) _last = index+1u; // possibly update last position
		}
		else if(!valid && TEST_MAP_BIT(low_map, index))
		{ 
			DISABLE_MAP_BIT(index); --_size;
			if(index == _last-1u) --_last; // possibly update last position
		}
	}

	// returns an open slot in the vector, if none it will expand
	uInt32 find_open(void)
	{
		// if the vector is full, expand it
		if(_size >= _capacity) _expand();
		// now... an open slot is garunteed	so lets find it.
		uInt32 shift = 0u, h_bit, l_bit;
		while(high_map[shift] == 0xFFFFFFFFu) ++shift; // move to an open 1024
		// now find an opening in the high map which leads to an opening in the low map.
		FIND_OPEN_BIT(h_bit, high_map[shift]); 
		shift = (shift << 5u) + h_bit;
		FIND_OPEN_BIT(l_bit, low_map[shift]); 
		return (shift << 5u) + l_bit;
	}

	// adds an item to the vector and returns its index (index is garunteed to stay valid)
	// the only operations that can effect indicies	are: collapse_left, collapse_right, insert, and erase.
	// keep in mind that push_back fills unused slots first, only then does it add to the end.
	uInt32 push_back(const T &val)
	{
		uInt32 _open = find_open();
		Data[_open] = val;
		ENABLE_MAP_BIT(_open);
		++_size;
		if(_open >= _last) _last = _open+1u; // update the _last spot
		return _open;
	}

	// Insert an element before a specific point
	// returns an iterator to the newly inserted element
	// this will distort indicies, use "push_back" if you want to maintain index intergrity.
	iterator insert(iterator point, const T &val)
	{
		// if the vector is full, or it cannot expand right, expand it
		iterator shift = --end();
		if(_size >= _capacity || ((uInt32)shift) == _capacity-1u) _expand();
		// shift all items right one spot
		while(shift != point)
		{
			DISABLE_MAP_BIT((uInt32)shift);
			ENABLE_MAP_BIT(((uInt32)shift)+1u);
			Data[(uInt32)shift+1u] = Data[(uInt32)shift];
			--shift;	
		}
		// shift current item in point
		Data[(uInt32)point + 1u] = Data[(uInt32)point];
		ENABLE_MAP_BIT((uInt32)point + 1u);
		// add item
		Data[(uInt32)point] = val; ++_size;
		// move the _last position, one to the right
		++_last;
		return point;
	}

	// removes the last valid item in the vector
	void pop_back(void)
	{
		if(!_size) return;
		set_valid((uInt32)--end(), false);
	}

	// return refrences to the first and last valid items.
	T &front(void) { return *begin(); }
	const T &front(void) const { return *begin(); }
	T &back(void) { return *(--end()); }
	const T &back(void) const { return *(--end()); }

	// removes an item from the vector (does not effect other items)
	// returns an iterator to the next valid item
	iterator remove(iterator rem) { set_valid(rem, false); return ++rem; }

	// removes all gaps from the vector, and lines data starting from the begining
	void collapse_left(void)
	{
		if(!_size || _size == _capacity) return;
		uInt32 track = 0u; // when track == _size, all items have been shifted left
		iterator find; // quickly find an item in use
		while(track < _size)
		{
			if(!TEST_MAP_BIT(low_map, track)) // determine if an empty spot must be filled
			{
				find = ++iterator(track, &arbiter); // find used item
				Data[track] = Data[(uInt32)find]; // fill the open slot with a valid item
				// update the bitmaps
				DISABLE_MAP_BIT((uInt32)find)
				ENABLE_MAP_BIT(track)
			}
			++track; // move to the next item
		}
		// update the last point
		_last = ((uInt32)(--iterator(_capacity,&arbiter)))+1u;
	}

	// removes all gaps from the vector, and lines data starting from the end
	void collapse_right(void)
	{
		if(!_size || _size == _capacity) return;
		uInt32 track = _capacity-1u; // when track < _capacity - _size, all items have been shifted right
		iterator find; // quickly find an item in use
		while(track >= (_capacity - _size))
		{
			if(!TEST_MAP_BIT(low_map, track)) // determine if an empty spot must be filled
			{
				find = --iterator(track, &arbiter); // find used item
				Data[track] = Data[(uInt32)find]; // fill the open slot with a valid item
				// update the bitmaps
				DISABLE_MAP_BIT((uInt32)find)
				ENABLE_MAP_BIT(track)
			}
			--track; // move to the prev item
		}
		// update the last point
		_last = _capacity;
	}

	// removes an item from the vector and collapses all items after it to the left
	// this will distort indicies, use "remove" if you want to maintain index intergrity.
	iterator erase(iterator ers)
	{
		// now collapse all following items
		if(!_size) return end();
		uInt32 track = (uInt32)ers;
		iterator find = ers; // quickly find an item in use
		iterator last = --end(); // last valid item in the list
		set_valid(ers, false); // gets rid of the item
		if(ers == last) return end();
		while(find != last)
		{
			if(!TEST_MAP_BIT(low_map, track)) // determine if an empty spot must be filled
			{
				++find;// = ++iterator(track, &arbiter); // find used item
				Data[track] = Data[(uInt32)find]; // fill the open slot with a valid item
				// update the bitmaps
				DISABLE_MAP_BIT((uInt32)find)
				ENABLE_MAP_BIT(track)
			}
			++track; // move to the next item
		}
		// update last point
		_last = track;
		return ers;
	}

	// clear the vector of all elements but do not effect its capacity
	void clear(void)
	{
		if(!_capacity) return;
		_size = 0u;
		_last = 0u;
		memset(low_map, 0u, lmap_sz << 2u);
		memset(high_map, 0u, hmap_sz << 2u);
	}

	// clean out the vector of all elements and capacity
	void _destroy(void)
	{
		delete [] high_map;
		delete [] low_map;
		delete [] Data;
		_create();
	}

};

// remove macros & defines
#undef uInt32
#undef Int32
#undef Bool8
#undef TEST_MAP_BIT
#undef ENABLE_MAP_BIT
#undef DISABLE_MAP_BIT
#undef _TEST_IF
#undef _TEST_ELSE
#undef _SET_IF
#undef _SET_ELSE
#undef FIND_OPEN_BIT

#endif