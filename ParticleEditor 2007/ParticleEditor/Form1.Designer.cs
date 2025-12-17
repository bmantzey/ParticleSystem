namespace ParticleEditor
{
	/// <summary>
	/// Form1 - Main form that contains all code for data generation of particle editor.
	/// </summary>
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.DXPanel = new System.Windows.Forms.Panel();
            this.EmitterControlsGroup = new System.Windows.Forms.GroupBox();
            this.EmitterPositionRand = new System.Windows.Forms.CheckBox();
            this.EmitterSizeRand = new System.Windows.Forms.CheckBox();
            this.EmitterDirectionRand = new System.Windows.Forms.CheckBox();
            this.EmitterSizeY = new System.Windows.Forms.NumericUpDown();
            this.EmitterSizeX = new System.Windows.Forms.NumericUpDown();
            this.EmitterPositionY = new System.Windows.Forms.NumericUpDown();
            this.EmitterDirectionEnd = new System.Windows.Forms.NumericUpDown();
            this.EmitterPositionX = new System.Windows.Forms.NumericUpDown();
            this.EmitterDirectionBegin = new System.Windows.Forms.NumericUpDown();
            this.EmitterSizeLabelY = new System.Windows.Forms.Label();
            this.EmitterSizeXLabel = new System.Windows.Forms.Label();
            this.EmitterSizeLabel = new System.Windows.Forms.Label();
            this.EmitterDirectionEndLabel = new System.Windows.Forms.Label();
            this.EmitterDirectionBeginLabel = new System.Windows.Forms.Label();
            this.EmitterDirectionLabel = new System.Windows.Forms.Label();
            this.EmitterPositionYLabel = new System.Windows.Forms.Label();
            this.EmitterPositionXLabel = new System.Windows.Forms.Label();
            this.EmitterPositionLabel = new System.Windows.Forms.Label();
            this.ParticleControlsGroup = new System.Windows.Forms.GroupBox();
            this.CheckAllColorRand = new System.Windows.Forms.CheckBox();
            this.RandomizeButton = new System.Windows.Forms.Button();
            this.ParticleMiliseconds = new System.Windows.Forms.Label();
            this.ParticleLifetimeEnd = new System.Windows.Forms.NumericUpDown();
            this.ParticleLifetimeTo = new System.Windows.Forms.Label();
            this.CheckAllRand = new System.Windows.Forms.CheckBox();
            this.ParticleSpeed = new System.Windows.Forms.NumericUpDown();
            this.ParticleLifetimeBegin = new System.Windows.Forms.NumericUpDown();
            this.ParticleNumber = new System.Windows.Forms.NumericUpDown();
            this.ParticleAccelerationX = new System.Windows.Forms.NumericUpDown();
            this.ParticleAccelerationY = new System.Windows.Forms.NumericUpDown();
            this.ParticleSizeBegin = new System.Windows.Forms.NumericUpDown();
            this.ParticleSizeEnd = new System.Windows.Forms.NumericUpDown();
            this.ParticleColorEndRedBox = new System.Windows.Forms.NumericUpDown();
            this.ParticleColorEndGreenBox = new System.Windows.Forms.NumericUpDown();
            this.ParticleColorEndBlueBox = new System.Windows.Forms.NumericUpDown();
            this.ParticleColorEndAlphaBox = new System.Windows.Forms.NumericUpDown();
            this.ParticleColorBeginAlphaBox = new System.Windows.Forms.NumericUpDown();
            this.ParticleColorBeginBlueBox = new System.Windows.Forms.NumericUpDown();
            this.ParticleColorBeginGreenBox = new System.Windows.Forms.NumericUpDown();
            this.ParticleColorBeginRedBox = new System.Windows.Forms.NumericUpDown();
            this.ParticleSpeedConstantLabel = new System.Windows.Forms.Label();
            this.ParticleColorEndRandLabel = new System.Windows.Forms.Label();
            this.ParticleColorBeginRandLabel = new System.Windows.Forms.Label();
            this.ParticleColorAlphaLabel = new System.Windows.Forms.Label();
            this.ParticleColorBlueLabel = new System.Windows.Forms.Label();
            this.ParticleColorGreenLabel = new System.Windows.Forms.Label();
            this.ParticleColorRedLabel = new System.Windows.Forms.Label();
            this.ParticleColorEndAlphaRand = new System.Windows.Forms.CheckBox();
            this.ParticleColorEndBlueRand = new System.Windows.Forms.CheckBox();
            this.ParticleColorEndGreenRand = new System.Windows.Forms.CheckBox();
            this.ParticleColorEndRedRand = new System.Windows.Forms.CheckBox();
            this.ParticleColorBeginAlphaRand = new System.Windows.Forms.CheckBox();
            this.ParticleColorBeginBlueRand = new System.Windows.Forms.CheckBox();
            this.ParticleColorBeginGreenRand = new System.Windows.Forms.CheckBox();
            this.ParticleColorBeginRedRand = new System.Windows.Forms.CheckBox();
            this.ParticleColorConstant = new System.Windows.Forms.CheckBox();
            this.ParticleColorLabel = new System.Windows.Forms.Label();
            this.ParticleColorEndAlphaTrack = new System.Windows.Forms.TrackBar();
            this.ParticleColorEndBlueTrack = new System.Windows.Forms.TrackBar();
            this.ParticleColorEndGreenTrack = new System.Windows.Forms.TrackBar();
            this.ParticleColorEndRedTrack = new System.Windows.Forms.TrackBar();
            this.ParticleColorEndLabel = new System.Windows.Forms.Label();
            this.ParticleColorBeginAlphaTrack = new System.Windows.Forms.TrackBar();
            this.ParticleColorBeginBlueTrack = new System.Windows.Forms.TrackBar();
            this.ParticleColorBeginGreenTrack = new System.Windows.Forms.TrackBar();
            this.ParticleColorBeginRedTrack = new System.Windows.Forms.TrackBar();
            this.ParticleColorBeginLabel = new System.Windows.Forms.Label();
            this.ParticleSizeEndRandom = new System.Windows.Forms.CheckBox();
            this.ParticleSizeBeginRandom = new System.Windows.Forms.CheckBox();
            this.ParticleSizeEndLabel = new System.Windows.Forms.Label();
            this.ParticleSizeConstant = new System.Windows.Forms.CheckBox();
            this.ParticleSizeLabel = new System.Windows.Forms.Label();
            this.ParticleSizeBeginLabel = new System.Windows.Forms.Label();
            this.ParticleAccelerationRandom = new System.Windows.Forms.CheckBox();
            this.ParticleAccelerationLabel = new System.Windows.Forms.Label();
            this.ParticleAccelerationYLabel = new System.Windows.Forms.Label();
            this.ParticleSpeedRandom = new System.Windows.Forms.CheckBox();
            this.ParticleAccelerationXLabel = new System.Windows.Forms.Label();
            this.ParticleSpeedConstant = new System.Windows.Forms.CheckBox();
            this.ParticleSpeedLabel = new System.Windows.Forms.Label();
            this.ParticleLifetimeRand = new System.Windows.Forms.CheckBox();
            this.ParticleLifetimeLabel = new System.Windows.Forms.Label();
            this.ParticleNumberRand = new System.Windows.Forms.CheckBox();
            this.ParticleNumberLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSavedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BGColor = new System.Windows.Forms.ColorDialog();
            this.EmitterControlsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmitterSizeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmitterSizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmitterPositionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmitterDirectionEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmitterPositionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmitterDirectionBegin)).BeginInit();
            this.ParticleControlsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleLifetimeEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleLifetimeBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleAccelerationX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleAccelerationY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleSizeBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleSizeEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorEndRedBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorEndGreenBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorEndBlueBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorEndAlphaBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorBeginAlphaBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorBeginBlueBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorBeginGreenBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorBeginRedBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorEndAlphaTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorEndBlueTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorEndGreenTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorEndRedTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorBeginAlphaTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorBeginBlueTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorBeginGreenTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorBeginRedTrack)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DXPanel
            // 
            this.DXPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DXPanel.Location = new System.Drawing.Point(5, 27);
            this.DXPanel.Name = "DXPanel";
            this.DXPanel.Size = new System.Drawing.Size(800, 600);
            this.DXPanel.TabIndex = 0;
            // 
            // EmitterControlsGroup
            // 
            this.EmitterControlsGroup.Controls.Add(this.EmitterPositionRand);
            this.EmitterControlsGroup.Controls.Add(this.EmitterSizeRand);
            this.EmitterControlsGroup.Controls.Add(this.EmitterDirectionRand);
            this.EmitterControlsGroup.Controls.Add(this.EmitterSizeY);
            this.EmitterControlsGroup.Controls.Add(this.EmitterSizeX);
            this.EmitterControlsGroup.Controls.Add(this.EmitterPositionY);
            this.EmitterControlsGroup.Controls.Add(this.EmitterDirectionEnd);
            this.EmitterControlsGroup.Controls.Add(this.EmitterPositionX);
            this.EmitterControlsGroup.Controls.Add(this.EmitterDirectionBegin);
            this.EmitterControlsGroup.Controls.Add(this.EmitterSizeLabelY);
            this.EmitterControlsGroup.Controls.Add(this.EmitterSizeXLabel);
            this.EmitterControlsGroup.Controls.Add(this.EmitterSizeLabel);
            this.EmitterControlsGroup.Controls.Add(this.EmitterDirectionEndLabel);
            this.EmitterControlsGroup.Controls.Add(this.EmitterDirectionBeginLabel);
            this.EmitterControlsGroup.Controls.Add(this.EmitterDirectionLabel);
            this.EmitterControlsGroup.Controls.Add(this.EmitterPositionYLabel);
            this.EmitterControlsGroup.Controls.Add(this.EmitterPositionXLabel);
            this.EmitterControlsGroup.Controls.Add(this.EmitterPositionLabel);
            this.EmitterControlsGroup.Location = new System.Drawing.Point(834, 35);
            this.EmitterControlsGroup.Name = "EmitterControlsGroup";
            this.EmitterControlsGroup.Size = new System.Drawing.Size(414, 123);
            this.EmitterControlsGroup.TabIndex = 1;
            this.EmitterControlsGroup.TabStop = false;
            this.EmitterControlsGroup.Text = "Emitter Controls";
            // 
            // EmitterPositionRand
            // 
            this.EmitterPositionRand.AutoSize = true;
            this.EmitterPositionRand.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmitterPositionRand.Location = new System.Drawing.Point(220, 14);
            this.EmitterPositionRand.Name = "EmitterPositionRand";
            this.EmitterPositionRand.Size = new System.Drawing.Size(71, 17);
            this.EmitterPositionRand.TabIndex = 96;
            this.EmitterPositionRand.TabStop = false;
            this.EmitterPositionRand.Text = "Random?";
            this.EmitterPositionRand.UseVisualStyleBackColor = true;
            // 
            // EmitterSizeRand
            // 
            this.EmitterSizeRand.AutoSize = true;
            this.EmitterSizeRand.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmitterSizeRand.Location = new System.Drawing.Point(220, 40);
            this.EmitterSizeRand.Name = "EmitterSizeRand";
            this.EmitterSizeRand.Size = new System.Drawing.Size(71, 17);
            this.EmitterSizeRand.TabIndex = 95;
            this.EmitterSizeRand.TabStop = false;
            this.EmitterSizeRand.Text = "Random?";
            this.EmitterSizeRand.UseVisualStyleBackColor = true;
            // 
            // EmitterDirectionRand
            // 
            this.EmitterDirectionRand.AutoSize = true;
            this.EmitterDirectionRand.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmitterDirectionRand.Location = new System.Drawing.Point(220, 91);
            this.EmitterDirectionRand.Name = "EmitterDirectionRand";
            this.EmitterDirectionRand.Size = new System.Drawing.Size(71, 17);
            this.EmitterDirectionRand.TabIndex = 94;
            this.EmitterDirectionRand.TabStop = false;
            this.EmitterDirectionRand.Text = "Random?";
            this.EmitterDirectionRand.UseVisualStyleBackColor = true;
            this.EmitterDirectionRand.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_3);
            // 
            // EmitterSizeY
            // 
            this.EmitterSizeY.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.EmitterSizeY.Location = new System.Drawing.Point(150, 38);
            this.EmitterSizeY.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.EmitterSizeY.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.EmitterSizeY.Name = "EmitterSizeY";
            this.EmitterSizeY.Size = new System.Drawing.Size(51, 20);
            this.EmitterSizeY.TabIndex = 4;
            this.EmitterSizeY.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.EmitterSizeY.ValueChanged += new System.EventHandler(this.EmitterSizeY_ValueChanged);
            // 
            // EmitterSizeX
            // 
            this.EmitterSizeX.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.EmitterSizeX.Location = new System.Drawing.Point(72, 38);
            this.EmitterSizeX.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.EmitterSizeX.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.EmitterSizeX.Name = "EmitterSizeX";
            this.EmitterSizeX.Size = new System.Drawing.Size(51, 20);
            this.EmitterSizeX.TabIndex = 3;
            this.EmitterSizeX.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.EmitterSizeX.ValueChanged += new System.EventHandler(this.EmitterSizeX_ValueChanged);
            // 
            // EmitterPositionY
            // 
            this.EmitterPositionY.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.EmitterPositionY.Location = new System.Drawing.Point(150, 12);
            this.EmitterPositionY.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.EmitterPositionY.Name = "EmitterPositionY";
            this.EmitterPositionY.Size = new System.Drawing.Size(51, 20);
            this.EmitterPositionY.TabIndex = 2;
            this.EmitterPositionY.ValueChanged += new System.EventHandler(this.EmitterPositionY_ValueChanged);
            // 
            // EmitterDirectionEnd
            // 
            this.EmitterDirectionEnd.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.EmitterDirectionEnd.Location = new System.Drawing.Point(163, 87);
            this.EmitterDirectionEnd.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.EmitterDirectionEnd.Name = "EmitterDirectionEnd";
            this.EmitterDirectionEnd.Size = new System.Drawing.Size(51, 20);
            this.EmitterDirectionEnd.TabIndex = 6;
            this.EmitterDirectionEnd.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.EmitterDirectionEnd.ValueChanged += new System.EventHandler(this.EmitterDirectionEnd_ValueChanged);
            // 
            // EmitterPositionX
            // 
            this.EmitterPositionX.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.EmitterPositionX.Location = new System.Drawing.Point(71, 12);
            this.EmitterPositionX.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.EmitterPositionX.Name = "EmitterPositionX";
            this.EmitterPositionX.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EmitterPositionX.Size = new System.Drawing.Size(53, 20);
            this.EmitterPositionX.TabIndex = 1;
            this.EmitterPositionX.ValueChanged += new System.EventHandler(this.EmitterPositionX_ValueChanged);
            // 
            // EmitterDirectionBegin
            // 
            this.EmitterDirectionBegin.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.EmitterDirectionBegin.Location = new System.Drawing.Point(72, 87);
            this.EmitterDirectionBegin.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.EmitterDirectionBegin.Name = "EmitterDirectionBegin";
            this.EmitterDirectionBegin.Size = new System.Drawing.Size(51, 20);
            this.EmitterDirectionBegin.TabIndex = 5;
            this.EmitterDirectionBegin.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.EmitterDirectionBegin.ValueChanged += new System.EventHandler(this.EmitterDirectionBegin_ValueChanged);
            // 
            // EmitterSizeLabelY
            // 
            this.EmitterSizeLabelY.AutoSize = true;
            this.EmitterSizeLabelY.Location = new System.Drawing.Point(126, 42);
            this.EmitterSizeLabelY.Name = "EmitterSizeLabelY";
            this.EmitterSizeLabelY.Size = new System.Drawing.Size(17, 13);
            this.EmitterSizeLabelY.TabIndex = 12;
            this.EmitterSizeLabelY.Text = "Y:";
            // 
            // EmitterSizeXLabel
            // 
            this.EmitterSizeXLabel.AutoSize = true;
            this.EmitterSizeXLabel.Location = new System.Drawing.Point(53, 42);
            this.EmitterSizeXLabel.Name = "EmitterSizeXLabel";
            this.EmitterSizeXLabel.Size = new System.Drawing.Size(17, 13);
            this.EmitterSizeXLabel.TabIndex = 11;
            this.EmitterSizeXLabel.Text = "X:";
            // 
            // EmitterSizeLabel
            // 
            this.EmitterSizeLabel.AutoSize = true;
            this.EmitterSizeLabel.Location = new System.Drawing.Point(21, 42);
            this.EmitterSizeLabel.Name = "EmitterSizeLabel";
            this.EmitterSizeLabel.Size = new System.Drawing.Size(30, 13);
            this.EmitterSizeLabel.TabIndex = 10;
            this.EmitterSizeLabel.Text = "Size:";
            // 
            // EmitterDirectionEndLabel
            // 
            this.EmitterDirectionEndLabel.AutoSize = true;
            this.EmitterDirectionEndLabel.Location = new System.Drawing.Point(128, 91);
            this.EmitterDirectionEndLabel.Name = "EmitterDirectionEndLabel";
            this.EmitterDirectionEndLabel.Size = new System.Drawing.Size(29, 13);
            this.EmitterDirectionEndLabel.TabIndex = 8;
            this.EmitterDirectionEndLabel.Text = "End:";
            // 
            // EmitterDirectionBeginLabel
            // 
            this.EmitterDirectionBeginLabel.AutoSize = true;
            this.EmitterDirectionBeginLabel.Location = new System.Drawing.Point(29, 91);
            this.EmitterDirectionBeginLabel.Name = "EmitterDirectionBeginLabel";
            this.EmitterDirectionBeginLabel.Size = new System.Drawing.Size(37, 13);
            this.EmitterDirectionBeginLabel.TabIndex = 6;
            this.EmitterDirectionBeginLabel.Text = "Begin:";
            // 
            // EmitterDirectionLabel
            // 
            this.EmitterDirectionLabel.AutoSize = true;
            this.EmitterDirectionLabel.Location = new System.Drawing.Point(6, 68);
            this.EmitterDirectionLabel.Name = "EmitterDirectionLabel";
            this.EmitterDirectionLabel.Size = new System.Drawing.Size(52, 13);
            this.EmitterDirectionLabel.TabIndex = 5;
            this.EmitterDirectionLabel.Text = "Direction:";
            // 
            // EmitterPositionYLabel
            // 
            this.EmitterPositionYLabel.AutoSize = true;
            this.EmitterPositionYLabel.Location = new System.Drawing.Point(127, 16);
            this.EmitterPositionYLabel.Name = "EmitterPositionYLabel";
            this.EmitterPositionYLabel.Size = new System.Drawing.Size(17, 13);
            this.EmitterPositionYLabel.TabIndex = 3;
            this.EmitterPositionYLabel.Text = "Y:";
            // 
            // EmitterPositionXLabel
            // 
            this.EmitterPositionXLabel.AutoSize = true;
            this.EmitterPositionXLabel.Location = new System.Drawing.Point(53, 16);
            this.EmitterPositionXLabel.Name = "EmitterPositionXLabel";
            this.EmitterPositionXLabel.Size = new System.Drawing.Size(17, 13);
            this.EmitterPositionXLabel.TabIndex = 1;
            this.EmitterPositionXLabel.Text = "X:";
            // 
            // EmitterPositionLabel
            // 
            this.EmitterPositionLabel.AutoSize = true;
            this.EmitterPositionLabel.Location = new System.Drawing.Point(6, 16);
            this.EmitterPositionLabel.Name = "EmitterPositionLabel";
            this.EmitterPositionLabel.Size = new System.Drawing.Size(47, 13);
            this.EmitterPositionLabel.TabIndex = 0;
            this.EmitterPositionLabel.Text = "Position:";
            // 
            // ParticleControlsGroup
            // 
            this.ParticleControlsGroup.Controls.Add(this.CheckAllColorRand);
            this.ParticleControlsGroup.Controls.Add(this.RandomizeButton);
            this.ParticleControlsGroup.Controls.Add(this.ParticleMiliseconds);
            this.ParticleControlsGroup.Controls.Add(this.ParticleLifetimeEnd);
            this.ParticleControlsGroup.Controls.Add(this.ParticleLifetimeTo);
            this.ParticleControlsGroup.Controls.Add(this.CheckAllRand);
            this.ParticleControlsGroup.Controls.Add(this.ParticleSpeed);
            this.ParticleControlsGroup.Controls.Add(this.ParticleLifetimeBegin);
            this.ParticleControlsGroup.Controls.Add(this.ParticleNumber);
            this.ParticleControlsGroup.Controls.Add(this.ParticleAccelerationX);
            this.ParticleControlsGroup.Controls.Add(this.ParticleAccelerationY);
            this.ParticleControlsGroup.Controls.Add(this.ParticleSizeBegin);
            this.ParticleControlsGroup.Controls.Add(this.ParticleSizeEnd);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorEndRedBox);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorEndGreenBox);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorEndBlueBox);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorEndAlphaBox);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorBeginAlphaBox);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorBeginBlueBox);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorBeginGreenBox);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorBeginRedBox);
            this.ParticleControlsGroup.Controls.Add(this.ParticleSpeedConstantLabel);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorEndRandLabel);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorBeginRandLabel);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorAlphaLabel);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorBlueLabel);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorGreenLabel);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorRedLabel);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorEndAlphaRand);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorEndBlueRand);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorEndGreenRand);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorEndRedRand);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorBeginAlphaRand);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorBeginBlueRand);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorBeginGreenRand);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorBeginRedRand);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorConstant);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorLabel);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorEndAlphaTrack);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorEndBlueTrack);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorEndGreenTrack);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorEndRedTrack);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorEndLabel);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorBeginAlphaTrack);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorBeginBlueTrack);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorBeginGreenTrack);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorBeginRedTrack);
            this.ParticleControlsGroup.Controls.Add(this.ParticleColorBeginLabel);
            this.ParticleControlsGroup.Controls.Add(this.ParticleSizeEndRandom);
            this.ParticleControlsGroup.Controls.Add(this.ParticleSizeBeginRandom);
            this.ParticleControlsGroup.Controls.Add(this.ParticleSizeEndLabel);
            this.ParticleControlsGroup.Controls.Add(this.ParticleSizeConstant);
            this.ParticleControlsGroup.Controls.Add(this.ParticleSizeLabel);
            this.ParticleControlsGroup.Controls.Add(this.ParticleSizeBeginLabel);
            this.ParticleControlsGroup.Controls.Add(this.ParticleAccelerationRandom);
            this.ParticleControlsGroup.Controls.Add(this.ParticleAccelerationLabel);
            this.ParticleControlsGroup.Controls.Add(this.ParticleAccelerationYLabel);
            this.ParticleControlsGroup.Controls.Add(this.ParticleSpeedRandom);
            this.ParticleControlsGroup.Controls.Add(this.ParticleAccelerationXLabel);
            this.ParticleControlsGroup.Controls.Add(this.ParticleSpeedConstant);
            this.ParticleControlsGroup.Controls.Add(this.ParticleSpeedLabel);
            this.ParticleControlsGroup.Controls.Add(this.ParticleLifetimeRand);
            this.ParticleControlsGroup.Controls.Add(this.ParticleLifetimeLabel);
            this.ParticleControlsGroup.Controls.Add(this.ParticleNumberRand);
            this.ParticleControlsGroup.Controls.Add(this.ParticleNumberLabel);
            this.ParticleControlsGroup.Location = new System.Drawing.Point(834, 164);
            this.ParticleControlsGroup.Name = "ParticleControlsGroup";
            this.ParticleControlsGroup.Size = new System.Drawing.Size(414, 384);
            this.ParticleControlsGroup.TabIndex = 2;
            this.ParticleControlsGroup.TabStop = false;
            this.ParticleControlsGroup.Text = "Particle Controls";
            // 
            // CheckAllColorRand
            // 
            this.CheckAllColorRand.AutoSize = true;
            this.CheckAllColorRand.Location = new System.Drawing.Point(151, 177);
            this.CheckAllColorRand.Name = "CheckAllColorRand";
            this.CheckAllColorRand.Size = new System.Drawing.Size(102, 17);
            this.CheckAllColorRand.TabIndex = 93;
            this.CheckAllColorRand.TabStop = false;
            this.CheckAllColorRand.Text = "Select All Colors";
            this.CheckAllColorRand.UseVisualStyleBackColor = true;
            this.CheckAllColorRand.CheckedChanged += new System.EventHandler(this.CheckAllColorRand_CheckedChanged);
            // 
            // RandomizeButton
            // 
            this.RandomizeButton.Location = new System.Drawing.Point(118, 350);
            this.RandomizeButton.Name = "RandomizeButton";
            this.RandomizeButton.Size = new System.Drawing.Size(75, 23);
            this.RandomizeButton.TabIndex = 23;
            this.RandomizeButton.Text = "Randomize!";
            this.RandomizeButton.UseVisualStyleBackColor = true;
            this.RandomizeButton.Click += new System.EventHandler(this.RandomizeButton_Click);
            // 
            // ParticleMiliseconds
            // 
            this.ParticleMiliseconds.AutoSize = true;
            this.ParticleMiliseconds.Location = new System.Drawing.Point(274, 43);
            this.ParticleMiliseconds.Name = "ParticleMiliseconds";
            this.ParticleMiliseconds.Size = new System.Drawing.Size(61, 13);
            this.ParticleMiliseconds.TabIndex = 92;
            this.ParticleMiliseconds.Text = "miliseconds";
            // 
            // ParticleLifetimeEnd
            // 
            this.ParticleLifetimeEnd.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ParticleLifetimeEnd.Location = new System.Drawing.Point(194, 41);
            this.ParticleLifetimeEnd.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.ParticleLifetimeEnd.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ParticleLifetimeEnd.Name = "ParticleLifetimeEnd";
            this.ParticleLifetimeEnd.Size = new System.Drawing.Size(74, 20);
            this.ParticleLifetimeEnd.TabIndex = 9;
            this.ParticleLifetimeEnd.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.ParticleLifetimeEnd.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // ParticleLifetimeTo
            // 
            this.ParticleLifetimeTo.AutoSize = true;
            this.ParticleLifetimeTo.Location = new System.Drawing.Point(169, 43);
            this.ParticleLifetimeTo.Name = "ParticleLifetimeTo";
            this.ParticleLifetimeTo.Size = new System.Drawing.Size(16, 13);
            this.ParticleLifetimeTo.TabIndex = 90;
            this.ParticleLifetimeTo.Text = "to";
            // 
            // CheckAllRand
            // 
            this.CheckAllRand.AutoSize = true;
            this.CheckAllRand.Location = new System.Drawing.Point(199, 354);
            this.CheckAllRand.Name = "CheckAllRand";
            this.CheckAllRand.Size = new System.Drawing.Size(113, 17);
            this.CheckAllRand.TabIndex = 89;
            this.CheckAllRand.TabStop = false;
            this.CheckAllRand.Text = "Select All Random";
            this.CheckAllRand.UseVisualStyleBackColor = true;
            this.CheckAllRand.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_2);
            // 
            // ParticleSpeed
            // 
            this.ParticleSpeed.DecimalPlaces = 2;
            this.ParticleSpeed.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ParticleSpeed.Location = new System.Drawing.Point(190, 68);
            this.ParticleSpeed.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.ParticleSpeed.Name = "ParticleSpeed";
            this.ParticleSpeed.Size = new System.Drawing.Size(73, 20);
            this.ParticleSpeed.TabIndex = 10;
            this.ParticleSpeed.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.ParticleSpeed.ValueChanged += new System.EventHandler(this.ParticleSpeed_ValueChanged);
            // 
            // ParticleLifetimeBegin
            // 
            this.ParticleLifetimeBegin.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ParticleLifetimeBegin.Location = new System.Drawing.Point(90, 41);
            this.ParticleLifetimeBegin.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.ParticleLifetimeBegin.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ParticleLifetimeBegin.Name = "ParticleLifetimeBegin";
            this.ParticleLifetimeBegin.Size = new System.Drawing.Size(74, 20);
            this.ParticleLifetimeBegin.TabIndex = 8;
            this.ParticleLifetimeBegin.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.ParticleLifetimeBegin.ValueChanged += new System.EventHandler(this.ParticleLifetimeBegin_ValueChanged);
            // 
            // ParticleNumber
            // 
            this.ParticleNumber.Location = new System.Drawing.Point(114, 14);
            this.ParticleNumber.Maximum = new decimal(new int[] {
            3500,
            0,
            0,
            0});
            this.ParticleNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ParticleNumber.Name = "ParticleNumber";
            this.ParticleNumber.Size = new System.Drawing.Size(64, 20);
            this.ParticleNumber.TabIndex = 7;
            this.ParticleNumber.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.ParticleNumber.ValueChanged += new System.EventHandler(this.ParticleNumber_ValueChanged);
            // 
            // ParticleAccelerationX
            // 
            this.ParticleAccelerationX.DecimalPlaces = 2;
            this.ParticleAccelerationX.Enabled = false;
            this.ParticleAccelerationX.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.ParticleAccelerationX.Location = new System.Drawing.Point(96, 94);
            this.ParticleAccelerationX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.ParticleAccelerationX.Name = "ParticleAccelerationX";
            this.ParticleAccelerationX.Size = new System.Drawing.Size(73, 20);
            this.ParticleAccelerationX.TabIndex = 11;
            this.ParticleAccelerationX.ValueChanged += new System.EventHandler(this.ParticleAccelerationX_ValueChanged);
            // 
            // ParticleAccelerationY
            // 
            this.ParticleAccelerationY.DecimalPlaces = 2;
            this.ParticleAccelerationY.Enabled = false;
            this.ParticleAccelerationY.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.ParticleAccelerationY.Location = new System.Drawing.Point(198, 94);
            this.ParticleAccelerationY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.ParticleAccelerationY.Name = "ParticleAccelerationY";
            this.ParticleAccelerationY.Size = new System.Drawing.Size(73, 20);
            this.ParticleAccelerationY.TabIndex = 12;
            this.ParticleAccelerationY.ValueChanged += new System.EventHandler(this.ParticleAccelerationY_ValueChanged);
            // 
            // ParticleSizeBegin
            // 
            this.ParticleSizeBegin.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.ParticleSizeBegin.Location = new System.Drawing.Point(153, 121);
            this.ParticleSizeBegin.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.ParticleSizeBegin.Name = "ParticleSizeBegin";
            this.ParticleSizeBegin.Size = new System.Drawing.Size(51, 20);
            this.ParticleSizeBegin.TabIndex = 13;
            this.ParticleSizeBegin.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.ParticleSizeBegin.ValueChanged += new System.EventHandler(this.ParticleSizeBeginX_ValueChanged);
            // 
            // ParticleSizeEnd
            // 
            this.ParticleSizeEnd.Enabled = false;
            this.ParticleSizeEnd.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.ParticleSizeEnd.Location = new System.Drawing.Point(154, 147);
            this.ParticleSizeEnd.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.ParticleSizeEnd.Name = "ParticleSizeEnd";
            this.ParticleSizeEnd.Size = new System.Drawing.Size(51, 20);
            this.ParticleSizeEnd.TabIndex = 14;
            this.ParticleSizeEnd.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.ParticleSizeEnd.ValueChanged += new System.EventHandler(this.ParticleSizeEndX_ValueChanged);
            // 
            // ParticleColorEndRedBox
            // 
            this.ParticleColorEndRedBox.Increment = new decimal(new int[] {
            19,
            0,
            0,
            0});
            this.ParticleColorEndRedBox.Location = new System.Drawing.Point(335, 223);
            this.ParticleColorEndRedBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ParticleColorEndRedBox.Name = "ParticleColorEndRedBox";
            this.ParticleColorEndRedBox.Size = new System.Drawing.Size(51, 20);
            this.ParticleColorEndRedBox.TabIndex = 19;
            this.ParticleColorEndRedBox.Value = new decimal(new int[] {
            126,
            0,
            0,
            0});
            this.ParticleColorEndRedBox.ValueChanged += new System.EventHandler(this.ParticleColorEndRedBox_ValueChanged);
            // 
            // ParticleColorEndGreenBox
            // 
            this.ParticleColorEndGreenBox.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ParticleColorEndGreenBox.Location = new System.Drawing.Point(335, 252);
            this.ParticleColorEndGreenBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ParticleColorEndGreenBox.Name = "ParticleColorEndGreenBox";
            this.ParticleColorEndGreenBox.Size = new System.Drawing.Size(51, 20);
            this.ParticleColorEndGreenBox.TabIndex = 20;
            this.ParticleColorEndGreenBox.Value = new decimal(new int[] {
            126,
            0,
            0,
            0});
            this.ParticleColorEndGreenBox.ValueChanged += new System.EventHandler(this.ParticleColorEndGreenBox_ValueChanged);
            // 
            // ParticleColorEndBlueBox
            // 
            this.ParticleColorEndBlueBox.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ParticleColorEndBlueBox.Location = new System.Drawing.Point(335, 283);
            this.ParticleColorEndBlueBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ParticleColorEndBlueBox.Name = "ParticleColorEndBlueBox";
            this.ParticleColorEndBlueBox.Size = new System.Drawing.Size(51, 20);
            this.ParticleColorEndBlueBox.TabIndex = 21;
            this.ParticleColorEndBlueBox.Value = new decimal(new int[] {
            126,
            0,
            0,
            0});
            this.ParticleColorEndBlueBox.ValueChanged += new System.EventHandler(this.ParticleColorEndBlueBox_ValueChanged);
            // 
            // ParticleColorEndAlphaBox
            // 
            this.ParticleColorEndAlphaBox.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ParticleColorEndAlphaBox.Location = new System.Drawing.Point(335, 318);
            this.ParticleColorEndAlphaBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ParticleColorEndAlphaBox.Name = "ParticleColorEndAlphaBox";
            this.ParticleColorEndAlphaBox.Size = new System.Drawing.Size(51, 20);
            this.ParticleColorEndAlphaBox.TabIndex = 22;
            this.ParticleColorEndAlphaBox.Value = new decimal(new int[] {
            126,
            0,
            0,
            0});
            this.ParticleColorEndAlphaBox.ValueChanged += new System.EventHandler(this.ParticleColorEndAlphaBox_ValueChanged);
            // 
            // ParticleColorBeginAlphaBox
            // 
            this.ParticleColorBeginAlphaBox.Increment = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.ParticleColorBeginAlphaBox.Location = new System.Drawing.Point(146, 318);
            this.ParticleColorBeginAlphaBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ParticleColorBeginAlphaBox.Name = "ParticleColorBeginAlphaBox";
            this.ParticleColorBeginAlphaBox.Size = new System.Drawing.Size(51, 20);
            this.ParticleColorBeginAlphaBox.TabIndex = 18;
            this.ParticleColorBeginAlphaBox.Value = new decimal(new int[] {
            126,
            0,
            0,
            0});
            this.ParticleColorBeginAlphaBox.ValueChanged += new System.EventHandler(this.ParticleColorBeginAlphaBox_ValueChanged);
            // 
            // ParticleColorBeginBlueBox
            // 
            this.ParticleColorBeginBlueBox.Increment = new decimal(new int[] {
            17,
            0,
            0,
            0});
            this.ParticleColorBeginBlueBox.Location = new System.Drawing.Point(146, 286);
            this.ParticleColorBeginBlueBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ParticleColorBeginBlueBox.Name = "ParticleColorBeginBlueBox";
            this.ParticleColorBeginBlueBox.Size = new System.Drawing.Size(51, 20);
            this.ParticleColorBeginBlueBox.TabIndex = 17;
            this.ParticleColorBeginBlueBox.Value = new decimal(new int[] {
            126,
            0,
            0,
            0});
            this.ParticleColorBeginBlueBox.ValueChanged += new System.EventHandler(this.ParticleColorBeginBlueBox_ValueChanged);
            // 
            // ParticleColorBeginGreenBox
            // 
            this.ParticleColorBeginGreenBox.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.ParticleColorBeginGreenBox.Location = new System.Drawing.Point(145, 252);
            this.ParticleColorBeginGreenBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ParticleColorBeginGreenBox.Name = "ParticleColorBeginGreenBox";
            this.ParticleColorBeginGreenBox.Size = new System.Drawing.Size(51, 20);
            this.ParticleColorBeginGreenBox.TabIndex = 16;
            this.ParticleColorBeginGreenBox.Value = new decimal(new int[] {
            126,
            0,
            0,
            0});
            this.ParticleColorBeginGreenBox.ValueChanged += new System.EventHandler(this.ParticleColorBeginGreenBox_ValueChanged);
            // 
            // ParticleColorBeginRedBox
            // 
            this.ParticleColorBeginRedBox.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.ParticleColorBeginRedBox.Location = new System.Drawing.Point(145, 223);
            this.ParticleColorBeginRedBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ParticleColorBeginRedBox.Name = "ParticleColorBeginRedBox";
            this.ParticleColorBeginRedBox.Size = new System.Drawing.Size(51, 20);
            this.ParticleColorBeginRedBox.TabIndex = 15;
            this.ParticleColorBeginRedBox.Value = new decimal(new int[] {
            126,
            0,
            0,
            0});
            this.ParticleColorBeginRedBox.ValueChanged += new System.EventHandler(this.ParticleColorBeginRedBox_ValueChanged);
            // 
            // ParticleSpeedConstantLabel
            // 
            this.ParticleSpeedConstantLabel.AutoSize = true;
            this.ParticleSpeedConstantLabel.Location = new System.Drawing.Point(123, 72);
            this.ParticleSpeedConstantLabel.Name = "ParticleSpeedConstantLabel";
            this.ParticleSpeedConstantLabel.Size = new System.Drawing.Size(52, 13);
            this.ParticleSpeedConstantLabel.TabIndex = 66;
            this.ParticleSpeedConstantLabel.Text = "Constant:";
            // 
            // ParticleColorEndRandLabel
            // 
            this.ParticleColorEndRandLabel.AutoSize = true;
            this.ParticleColorEndRandLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParticleColorEndRandLabel.Location = new System.Drawing.Point(373, 201);
            this.ParticleColorEndRandLabel.Name = "ParticleColorEndRandLabel";
            this.ParticleColorEndRandLabel.Size = new System.Drawing.Size(32, 13);
            this.ParticleColorEndRandLabel.TabIndex = 64;
            this.ParticleColorEndRandLabel.Text = "Rand";
            // 
            // ParticleColorBeginRandLabel
            // 
            this.ParticleColorBeginRandLabel.AutoSize = true;
            this.ParticleColorBeginRandLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParticleColorBeginRandLabel.Location = new System.Drawing.Point(191, 201);
            this.ParticleColorBeginRandLabel.Name = "ParticleColorBeginRandLabel";
            this.ParticleColorBeginRandLabel.Size = new System.Drawing.Size(32, 13);
            this.ParticleColorBeginRandLabel.TabIndex = 63;
            this.ParticleColorBeginRandLabel.Text = "Rand";
            // 
            // ParticleColorAlphaLabel
            // 
            this.ParticleColorAlphaLabel.AutoSize = true;
            this.ParticleColorAlphaLabel.Location = new System.Drawing.Point(6, 320);
            this.ParticleColorAlphaLabel.Name = "ParticleColorAlphaLabel";
            this.ParticleColorAlphaLabel.Size = new System.Drawing.Size(14, 13);
            this.ParticleColorAlphaLabel.TabIndex = 62;
            this.ParticleColorAlphaLabel.Text = "A";
            // 
            // ParticleColorBlueLabel
            // 
            this.ParticleColorBlueLabel.AutoSize = true;
            this.ParticleColorBlueLabel.Location = new System.Drawing.Point(6, 286);
            this.ParticleColorBlueLabel.Name = "ParticleColorBlueLabel";
            this.ParticleColorBlueLabel.Size = new System.Drawing.Size(14, 13);
            this.ParticleColorBlueLabel.TabIndex = 61;
            this.ParticleColorBlueLabel.Text = "B";
            // 
            // ParticleColorGreenLabel
            // 
            this.ParticleColorGreenLabel.AutoSize = true;
            this.ParticleColorGreenLabel.Location = new System.Drawing.Point(6, 255);
            this.ParticleColorGreenLabel.Name = "ParticleColorGreenLabel";
            this.ParticleColorGreenLabel.Size = new System.Drawing.Size(15, 13);
            this.ParticleColorGreenLabel.TabIndex = 60;
            this.ParticleColorGreenLabel.Text = "G";
            // 
            // ParticleColorRedLabel
            // 
            this.ParticleColorRedLabel.AutoSize = true;
            this.ParticleColorRedLabel.Location = new System.Drawing.Point(4, 225);
            this.ParticleColorRedLabel.Name = "ParticleColorRedLabel";
            this.ParticleColorRedLabel.Size = new System.Drawing.Size(15, 13);
            this.ParticleColorRedLabel.TabIndex = 59;
            this.ParticleColorRedLabel.Text = "R";
            // 
            // ParticleColorEndAlphaRand
            // 
            this.ParticleColorEndAlphaRand.AutoSize = true;
            this.ParticleColorEndAlphaRand.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParticleColorEndAlphaRand.Location = new System.Drawing.Point(388, 321);
            this.ParticleColorEndAlphaRand.Name = "ParticleColorEndAlphaRand";
            this.ParticleColorEndAlphaRand.Size = new System.Drawing.Size(15, 14);
            this.ParticleColorEndAlphaRand.TabIndex = 58;
            this.ParticleColorEndAlphaRand.TabStop = false;
            this.ParticleColorEndAlphaRand.UseVisualStyleBackColor = true;
            this.ParticleColorEndAlphaRand.CheckedChanged += new System.EventHandler(this.ParticleColorEndAlphaRand_CheckedChanged);
            // 
            // ParticleColorEndBlueRand
            // 
            this.ParticleColorEndBlueRand.AutoSize = true;
            this.ParticleColorEndBlueRand.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParticleColorEndBlueRand.Location = new System.Drawing.Point(388, 287);
            this.ParticleColorEndBlueRand.Name = "ParticleColorEndBlueRand";
            this.ParticleColorEndBlueRand.Size = new System.Drawing.Size(15, 14);
            this.ParticleColorEndBlueRand.TabIndex = 57;
            this.ParticleColorEndBlueRand.TabStop = false;
            this.ParticleColorEndBlueRand.UseVisualStyleBackColor = true;
            this.ParticleColorEndBlueRand.CheckedChanged += new System.EventHandler(this.ParticleColorEndBlueRand_CheckedChanged);
            // 
            // ParticleColorEndGreenRand
            // 
            this.ParticleColorEndGreenRand.AutoSize = true;
            this.ParticleColorEndGreenRand.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParticleColorEndGreenRand.Location = new System.Drawing.Point(388, 256);
            this.ParticleColorEndGreenRand.Name = "ParticleColorEndGreenRand";
            this.ParticleColorEndGreenRand.Size = new System.Drawing.Size(15, 14);
            this.ParticleColorEndGreenRand.TabIndex = 56;
            this.ParticleColorEndGreenRand.TabStop = false;
            this.ParticleColorEndGreenRand.UseVisualStyleBackColor = true;
            this.ParticleColorEndGreenRand.CheckedChanged += new System.EventHandler(this.ParticleColorEndGreenRand_CheckedChanged);
            // 
            // ParticleColorEndRedRand
            // 
            this.ParticleColorEndRedRand.AutoSize = true;
            this.ParticleColorEndRedRand.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParticleColorEndRedRand.Location = new System.Drawing.Point(388, 226);
            this.ParticleColorEndRedRand.Name = "ParticleColorEndRedRand";
            this.ParticleColorEndRedRand.Size = new System.Drawing.Size(15, 14);
            this.ParticleColorEndRedRand.TabIndex = 55;
            this.ParticleColorEndRedRand.TabStop = false;
            this.ParticleColorEndRedRand.UseVisualStyleBackColor = true;
            this.ParticleColorEndRedRand.CheckedChanged += new System.EventHandler(this.ParticleColorEndRedRand_CheckedChanged);
            // 
            // ParticleColorBeginAlphaRand
            // 
            this.ParticleColorBeginAlphaRand.AutoSize = true;
            this.ParticleColorBeginAlphaRand.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParticleColorBeginAlphaRand.Location = new System.Drawing.Point(200, 320);
            this.ParticleColorBeginAlphaRand.Name = "ParticleColorBeginAlphaRand";
            this.ParticleColorBeginAlphaRand.Size = new System.Drawing.Size(15, 14);
            this.ParticleColorBeginAlphaRand.TabIndex = 54;
            this.ParticleColorBeginAlphaRand.TabStop = false;
            this.ParticleColorBeginAlphaRand.UseVisualStyleBackColor = true;
            this.ParticleColorBeginAlphaRand.CheckedChanged += new System.EventHandler(this.ParticleColorBeginAlphaRand_CheckedChanged);
            // 
            // ParticleColorBeginBlueRand
            // 
            this.ParticleColorBeginBlueRand.AutoSize = true;
            this.ParticleColorBeginBlueRand.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParticleColorBeginBlueRand.Location = new System.Drawing.Point(200, 286);
            this.ParticleColorBeginBlueRand.Name = "ParticleColorBeginBlueRand";
            this.ParticleColorBeginBlueRand.Size = new System.Drawing.Size(15, 14);
            this.ParticleColorBeginBlueRand.TabIndex = 53;
            this.ParticleColorBeginBlueRand.TabStop = false;
            this.ParticleColorBeginBlueRand.UseVisualStyleBackColor = true;
            this.ParticleColorBeginBlueRand.CheckedChanged += new System.EventHandler(this.ParticleColorBeginBlueRand_CheckedChanged);
            // 
            // ParticleColorBeginGreenRand
            // 
            this.ParticleColorBeginGreenRand.AutoSize = true;
            this.ParticleColorBeginGreenRand.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParticleColorBeginGreenRand.Location = new System.Drawing.Point(200, 255);
            this.ParticleColorBeginGreenRand.Name = "ParticleColorBeginGreenRand";
            this.ParticleColorBeginGreenRand.Size = new System.Drawing.Size(15, 14);
            this.ParticleColorBeginGreenRand.TabIndex = 52;
            this.ParticleColorBeginGreenRand.TabStop = false;
            this.ParticleColorBeginGreenRand.UseVisualStyleBackColor = true;
            this.ParticleColorBeginGreenRand.CheckedChanged += new System.EventHandler(this.ParticleColorBeginGreenRand_CheckedChanged);
            // 
            // ParticleColorBeginRedRand
            // 
            this.ParticleColorBeginRedRand.AutoSize = true;
            this.ParticleColorBeginRedRand.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParticleColorBeginRedRand.Location = new System.Drawing.Point(200, 225);
            this.ParticleColorBeginRedRand.Name = "ParticleColorBeginRedRand";
            this.ParticleColorBeginRedRand.Size = new System.Drawing.Size(15, 14);
            this.ParticleColorBeginRedRand.TabIndex = 51;
            this.ParticleColorBeginRedRand.TabStop = false;
            this.ParticleColorBeginRedRand.UseVisualStyleBackColor = true;
            this.ParticleColorBeginRedRand.CheckedChanged += new System.EventHandler(this.ParticleColorBeginRedRand_CheckedChanged);
            // 
            // ParticleColorConstant
            // 
            this.ParticleColorConstant.AutoSize = true;
            this.ParticleColorConstant.Location = new System.Drawing.Point(53, 176);
            this.ParticleColorConstant.Name = "ParticleColorConstant";
            this.ParticleColorConstant.Size = new System.Drawing.Size(74, 17);
            this.ParticleColorConstant.TabIndex = 42;
            this.ParticleColorConstant.TabStop = false;
            this.ParticleColorConstant.Text = "Constant?";
            this.ParticleColorConstant.UseVisualStyleBackColor = true;
            this.ParticleColorConstant.Visible = false;
            this.ParticleColorConstant.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // ParticleColorLabel
            // 
            this.ParticleColorLabel.AutoSize = true;
            this.ParticleColorLabel.Location = new System.Drawing.Point(6, 177);
            this.ParticleColorLabel.Name = "ParticleColorLabel";
            this.ParticleColorLabel.Size = new System.Drawing.Size(34, 13);
            this.ParticleColorLabel.TabIndex = 41;
            this.ParticleColorLabel.Text = "Color:";
            // 
            // ParticleColorEndAlphaTrack
            // 
            this.ParticleColorEndAlphaTrack.Location = new System.Drawing.Point(214, 320);
            this.ParticleColorEndAlphaTrack.Maximum = 255;
            this.ParticleColorEndAlphaTrack.Name = "ParticleColorEndAlphaTrack";
            this.ParticleColorEndAlphaTrack.Size = new System.Drawing.Size(125, 45);
            this.ParticleColorEndAlphaTrack.TabIndex = 40;
            this.ParticleColorEndAlphaTrack.TabStop = false;
            this.ParticleColorEndAlphaTrack.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ParticleColorEndAlphaTrack.Value = 126;
            this.ParticleColorEndAlphaTrack.ValueChanged += new System.EventHandler(this.ParticleColorEndAlphaTrack_ValueChanged);
            this.ParticleColorEndAlphaTrack.Scroll += new System.EventHandler(this.ParticleColorEndAlphaTrack_Scroll);
            // 
            // ParticleColorEndBlueTrack
            // 
            this.ParticleColorEndBlueTrack.Location = new System.Drawing.Point(214, 285);
            this.ParticleColorEndBlueTrack.Maximum = 255;
            this.ParticleColorEndBlueTrack.Name = "ParticleColorEndBlueTrack";
            this.ParticleColorEndBlueTrack.Size = new System.Drawing.Size(125, 45);
            this.ParticleColorEndBlueTrack.TabIndex = 39;
            this.ParticleColorEndBlueTrack.TabStop = false;
            this.ParticleColorEndBlueTrack.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ParticleColorEndBlueTrack.Value = 126;
            this.ParticleColorEndBlueTrack.ValueChanged += new System.EventHandler(this.ParticleColorEndBlueTrack_ValueChanged);
            this.ParticleColorEndBlueTrack.Scroll += new System.EventHandler(this.ParticleColorEndBlueTrack_Scroll);
            // 
            // ParticleColorEndGreenTrack
            // 
            this.ParticleColorEndGreenTrack.Location = new System.Drawing.Point(214, 252);
            this.ParticleColorEndGreenTrack.Maximum = 255;
            this.ParticleColorEndGreenTrack.Name = "ParticleColorEndGreenTrack";
            this.ParticleColorEndGreenTrack.Size = new System.Drawing.Size(125, 45);
            this.ParticleColorEndGreenTrack.TabIndex = 38;
            this.ParticleColorEndGreenTrack.TabStop = false;
            this.ParticleColorEndGreenTrack.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ParticleColorEndGreenTrack.Value = 126;
            this.ParticleColorEndGreenTrack.ValueChanged += new System.EventHandler(this.ParticleColorEndGreenTrack_ValueChanged);
            this.ParticleColorEndGreenTrack.Scroll += new System.EventHandler(this.ParticleColorEndGreenTrack_Scroll);
            // 
            // ParticleColorEndRedTrack
            // 
            this.ParticleColorEndRedTrack.Location = new System.Drawing.Point(214, 221);
            this.ParticleColorEndRedTrack.Maximum = 255;
            this.ParticleColorEndRedTrack.Name = "ParticleColorEndRedTrack";
            this.ParticleColorEndRedTrack.Size = new System.Drawing.Size(125, 45);
            this.ParticleColorEndRedTrack.TabIndex = 37;
            this.ParticleColorEndRedTrack.TabStop = false;
            this.ParticleColorEndRedTrack.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ParticleColorEndRedTrack.Value = 126;
            this.ParticleColorEndRedTrack.ValueChanged += new System.EventHandler(this.ParticleColorEndRedTrack_ValueChanged);
            this.ParticleColorEndRedTrack.Scroll += new System.EventHandler(this.ParticleColorEndRedTrack_Scroll);
            // 
            // ParticleColorEndLabel
            // 
            this.ParticleColorEndLabel.AutoSize = true;
            this.ParticleColorEndLabel.Location = new System.Drawing.Point(258, 200);
            this.ParticleColorEndLabel.Name = "ParticleColorEndLabel";
            this.ParticleColorEndLabel.Size = new System.Drawing.Size(53, 13);
            this.ParticleColorEndLabel.TabIndex = 36;
            this.ParticleColorEndLabel.Text = "End Color";
            // 
            // ParticleColorBeginAlphaTrack
            // 
            this.ParticleColorBeginAlphaTrack.Location = new System.Drawing.Point(21, 320);
            this.ParticleColorBeginAlphaTrack.Maximum = 255;
            this.ParticleColorBeginAlphaTrack.Name = "ParticleColorBeginAlphaTrack";
            this.ParticleColorBeginAlphaTrack.Size = new System.Drawing.Size(125, 45);
            this.ParticleColorBeginAlphaTrack.TabIndex = 35;
            this.ParticleColorBeginAlphaTrack.TabStop = false;
            this.ParticleColorBeginAlphaTrack.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ParticleColorBeginAlphaTrack.Value = 126;
            this.ParticleColorBeginAlphaTrack.ValueChanged += new System.EventHandler(this.ParticleColorBeginAlphaTrack_ValueChanged);
            this.ParticleColorBeginAlphaTrack.Scroll += new System.EventHandler(this.ParticleColorBeginAlphaTrack_Scroll);
            // 
            // ParticleColorBeginBlueTrack
            // 
            this.ParticleColorBeginBlueTrack.Location = new System.Drawing.Point(21, 285);
            this.ParticleColorBeginBlueTrack.Maximum = 255;
            this.ParticleColorBeginBlueTrack.Name = "ParticleColorBeginBlueTrack";
            this.ParticleColorBeginBlueTrack.Size = new System.Drawing.Size(125, 45);
            this.ParticleColorBeginBlueTrack.TabIndex = 34;
            this.ParticleColorBeginBlueTrack.TabStop = false;
            this.ParticleColorBeginBlueTrack.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ParticleColorBeginBlueTrack.Value = 126;
            this.ParticleColorBeginBlueTrack.ValueChanged += new System.EventHandler(this.ParticleColorBeginBlueTrack_ValueChanged);
            this.ParticleColorBeginBlueTrack.Scroll += new System.EventHandler(this.ParticleColorBeginBlueTrack_Scroll);
            // 
            // ParticleColorBeginGreenTrack
            // 
            this.ParticleColorBeginGreenTrack.Location = new System.Drawing.Point(21, 252);
            this.ParticleColorBeginGreenTrack.Maximum = 255;
            this.ParticleColorBeginGreenTrack.Name = "ParticleColorBeginGreenTrack";
            this.ParticleColorBeginGreenTrack.Size = new System.Drawing.Size(125, 45);
            this.ParticleColorBeginGreenTrack.TabIndex = 33;
            this.ParticleColorBeginGreenTrack.TabStop = false;
            this.ParticleColorBeginGreenTrack.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ParticleColorBeginGreenTrack.Value = 126;
            this.ParticleColorBeginGreenTrack.ValueChanged += new System.EventHandler(this.ParticleColorBeginGreenTrack_ValueChanged);
            this.ParticleColorBeginGreenTrack.Scroll += new System.EventHandler(this.ParticleColorBeginGreenTrack_Scroll);
            // 
            // ParticleColorBeginRedTrack
            // 
            this.ParticleColorBeginRedTrack.Location = new System.Drawing.Point(21, 221);
            this.ParticleColorBeginRedTrack.Maximum = 255;
            this.ParticleColorBeginRedTrack.Name = "ParticleColorBeginRedTrack";
            this.ParticleColorBeginRedTrack.Size = new System.Drawing.Size(125, 45);
            this.ParticleColorBeginRedTrack.TabIndex = 32;
            this.ParticleColorBeginRedTrack.TabStop = false;
            this.ParticleColorBeginRedTrack.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ParticleColorBeginRedTrack.Value = 126;
            this.ParticleColorBeginRedTrack.ValueChanged += new System.EventHandler(this.ParticleColorBeginRedTrack_ValueChanged);
            this.ParticleColorBeginRedTrack.Scroll += new System.EventHandler(this.ParticleColorBeginRedTrack_Scroll);
            // 
            // ParticleColorBeginLabel
            // 
            this.ParticleColorBeginLabel.AutoSize = true;
            this.ParticleColorBeginLabel.Location = new System.Drawing.Point(40, 200);
            this.ParticleColorBeginLabel.Name = "ParticleColorBeginLabel";
            this.ParticleColorBeginLabel.Size = new System.Drawing.Size(76, 13);
            this.ParticleColorBeginLabel.TabIndex = 31;
            this.ParticleColorBeginLabel.Text = "Constant Color";
            // 
            // ParticleSizeEndRandom
            // 
            this.ParticleSizeEndRandom.AutoSize = true;
            this.ParticleSizeEndRandom.Enabled = false;
            this.ParticleSizeEndRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParticleSizeEndRandom.Location = new System.Drawing.Point(213, 147);
            this.ParticleSizeEndRandom.Name = "ParticleSizeEndRandom";
            this.ParticleSizeEndRandom.Size = new System.Drawing.Size(71, 17);
            this.ParticleSizeEndRandom.TabIndex = 30;
            this.ParticleSizeEndRandom.TabStop = false;
            this.ParticleSizeEndRandom.Text = "Random?";
            this.ParticleSizeEndRandom.UseVisualStyleBackColor = true;
            this.ParticleSizeEndRandom.CheckedChanged += new System.EventHandler(this.ParticleSizeEndRandom_CheckedChanged);
            // 
            // ParticleSizeBeginRandom
            // 
            this.ParticleSizeBeginRandom.AutoSize = true;
            this.ParticleSizeBeginRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParticleSizeBeginRandom.Location = new System.Drawing.Point(213, 125);
            this.ParticleSizeBeginRandom.Name = "ParticleSizeBeginRandom";
            this.ParticleSizeBeginRandom.Size = new System.Drawing.Size(71, 17);
            this.ParticleSizeBeginRandom.TabIndex = 29;
            this.ParticleSizeBeginRandom.TabStop = false;
            this.ParticleSizeBeginRandom.Text = "Random?";
            this.ParticleSizeBeginRandom.UseVisualStyleBackColor = true;
            this.ParticleSizeBeginRandom.CheckedChanged += new System.EventHandler(this.ParticleSizeBeginRandom_CheckedChanged);
            // 
            // ParticleSizeEndLabel
            // 
            this.ParticleSizeEndLabel.AutoSize = true;
            this.ParticleSizeEndLabel.Enabled = false;
            this.ParticleSizeEndLabel.Location = new System.Drawing.Point(114, 149);
            this.ParticleSizeEndLabel.Name = "ParticleSizeEndLabel";
            this.ParticleSizeEndLabel.Size = new System.Drawing.Size(29, 13);
            this.ParticleSizeEndLabel.TabIndex = 24;
            this.ParticleSizeEndLabel.Text = "End:";
            // 
            // ParticleSizeConstant
            // 
            this.ParticleSizeConstant.AutoSize = true;
            this.ParticleSizeConstant.Checked = true;
            this.ParticleSizeConstant.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ParticleSizeConstant.Location = new System.Drawing.Point(37, 123);
            this.ParticleSizeConstant.Name = "ParticleSizeConstant";
            this.ParticleSizeConstant.Size = new System.Drawing.Size(74, 17);
            this.ParticleSizeConstant.TabIndex = 21;
            this.ParticleSizeConstant.TabStop = false;
            this.ParticleSizeConstant.Text = "Constant?";
            this.ParticleSizeConstant.UseVisualStyleBackColor = true;
            this.ParticleSizeConstant.CheckedChanged += new System.EventHandler(this.ParticleSizeConstant_CheckedChanged);
            // 
            // ParticleSizeLabel
            // 
            this.ParticleSizeLabel.AutoSize = true;
            this.ParticleSizeLabel.Location = new System.Drawing.Point(6, 125);
            this.ParticleSizeLabel.Name = "ParticleSizeLabel";
            this.ParticleSizeLabel.Size = new System.Drawing.Size(30, 13);
            this.ParticleSizeLabel.TabIndex = 20;
            this.ParticleSizeLabel.Text = "Size:";
            // 
            // ParticleSizeBeginLabel
            // 
            this.ParticleSizeBeginLabel.AutoSize = true;
            this.ParticleSizeBeginLabel.Location = new System.Drawing.Point(111, 124);
            this.ParticleSizeBeginLabel.Name = "ParticleSizeBeginLabel";
            this.ParticleSizeBeginLabel.Size = new System.Drawing.Size(37, 13);
            this.ParticleSizeBeginLabel.TabIndex = 15;
            this.ParticleSizeBeginLabel.Text = "Begin:";
            // 
            // ParticleAccelerationRandom
            // 
            this.ParticleAccelerationRandom.AutoSize = true;
            this.ParticleAccelerationRandom.Enabled = false;
            this.ParticleAccelerationRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParticleAccelerationRandom.Location = new System.Drawing.Point(277, 96);
            this.ParticleAccelerationRandom.Name = "ParticleAccelerationRandom";
            this.ParticleAccelerationRandom.Size = new System.Drawing.Size(71, 17);
            this.ParticleAccelerationRandom.TabIndex = 19;
            this.ParticleAccelerationRandom.TabStop = false;
            this.ParticleAccelerationRandom.Text = "Random?";
            this.ParticleAccelerationRandom.UseVisualStyleBackColor = true;
            this.ParticleAccelerationRandom.CheckedChanged += new System.EventHandler(this.ParticleAccelerationRandom_CheckedChanged);
            // 
            // ParticleAccelerationLabel
            // 
            this.ParticleAccelerationLabel.AutoSize = true;
            this.ParticleAccelerationLabel.Enabled = false;
            this.ParticleAccelerationLabel.Location = new System.Drawing.Point(6, 98);
            this.ParticleAccelerationLabel.Name = "ParticleAccelerationLabel";
            this.ParticleAccelerationLabel.Size = new System.Drawing.Size(69, 13);
            this.ParticleAccelerationLabel.TabIndex = 10;
            this.ParticleAccelerationLabel.Text = "Acceleration:";
            // 
            // ParticleAccelerationYLabel
            // 
            this.ParticleAccelerationYLabel.AutoSize = true;
            this.ParticleAccelerationYLabel.Enabled = false;
            this.ParticleAccelerationYLabel.Location = new System.Drawing.Point(175, 98);
            this.ParticleAccelerationYLabel.Name = "ParticleAccelerationYLabel";
            this.ParticleAccelerationYLabel.Size = new System.Drawing.Size(17, 13);
            this.ParticleAccelerationYLabel.TabIndex = 17;
            this.ParticleAccelerationYLabel.Text = "Y:";
            // 
            // ParticleSpeedRandom
            // 
            this.ParticleSpeedRandom.AutoSize = true;
            this.ParticleSpeedRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParticleSpeedRandom.Location = new System.Drawing.Point(269, 70);
            this.ParticleSpeedRandom.Name = "ParticleSpeedRandom";
            this.ParticleSpeedRandom.Size = new System.Drawing.Size(71, 17);
            this.ParticleSpeedRandom.TabIndex = 9;
            this.ParticleSpeedRandom.TabStop = false;
            this.ParticleSpeedRandom.Text = "Random?";
            this.ParticleSpeedRandom.UseVisualStyleBackColor = true;
            this.ParticleSpeedRandom.CheckedChanged += new System.EventHandler(this.ParticleSpeedRandom_CheckedChanged);
            // 
            // ParticleAccelerationXLabel
            // 
            this.ParticleAccelerationXLabel.AutoSize = true;
            this.ParticleAccelerationXLabel.Enabled = false;
            this.ParticleAccelerationXLabel.Location = new System.Drawing.Point(76, 98);
            this.ParticleAccelerationXLabel.Name = "ParticleAccelerationXLabel";
            this.ParticleAccelerationXLabel.Size = new System.Drawing.Size(17, 13);
            this.ParticleAccelerationXLabel.TabIndex = 15;
            this.ParticleAccelerationXLabel.Text = "X:";
            // 
            // ParticleSpeedConstant
            // 
            this.ParticleSpeedConstant.AutoSize = true;
            this.ParticleSpeedConstant.Checked = true;
            this.ParticleSpeedConstant.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ParticleSpeedConstant.Location = new System.Drawing.Point(53, 70);
            this.ParticleSpeedConstant.Name = "ParticleSpeedConstant";
            this.ParticleSpeedConstant.Size = new System.Drawing.Size(74, 17);
            this.ParticleSpeedConstant.TabIndex = 7;
            this.ParticleSpeedConstant.TabStop = false;
            this.ParticleSpeedConstant.Text = "Constant?";
            this.ParticleSpeedConstant.UseVisualStyleBackColor = true;
            this.ParticleSpeedConstant.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ParticleSpeedLabel
            // 
            this.ParticleSpeedLabel.AutoSize = true;
            this.ParticleSpeedLabel.Location = new System.Drawing.Point(6, 72);
            this.ParticleSpeedLabel.Name = "ParticleSpeedLabel";
            this.ParticleSpeedLabel.Size = new System.Drawing.Size(41, 13);
            this.ParticleSpeedLabel.TabIndex = 6;
            this.ParticleSpeedLabel.Text = "Speed:";
            // 
            // ParticleLifetimeRand
            // 
            this.ParticleLifetimeRand.AutoSize = true;
            this.ParticleLifetimeRand.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParticleLifetimeRand.Location = new System.Drawing.Point(341, 43);
            this.ParticleLifetimeRand.Name = "ParticleLifetimeRand";
            this.ParticleLifetimeRand.Size = new System.Drawing.Size(71, 17);
            this.ParticleLifetimeRand.TabIndex = 5;
            this.ParticleLifetimeRand.TabStop = false;
            this.ParticleLifetimeRand.Text = "Random?";
            this.ParticleLifetimeRand.UseVisualStyleBackColor = true;
            this.ParticleLifetimeRand.CheckedChanged += new System.EventHandler(this.ParticleLifetimeRand_CheckedChanged);
            // 
            // ParticleLifetimeLabel
            // 
            this.ParticleLifetimeLabel.AutoSize = true;
            this.ParticleLifetimeLabel.Location = new System.Drawing.Point(6, 43);
            this.ParticleLifetimeLabel.Name = "ParticleLifetimeLabel";
            this.ParticleLifetimeLabel.Size = new System.Drawing.Size(81, 13);
            this.ParticleLifetimeLabel.TabIndex = 3;
            this.ParticleLifetimeLabel.Text = "Lifetime Range:";
            // 
            // ParticleNumberRand
            // 
            this.ParticleNumberRand.AutoSize = true;
            this.ParticleNumberRand.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParticleNumberRand.Location = new System.Drawing.Point(184, 16);
            this.ParticleNumberRand.Name = "ParticleNumberRand";
            this.ParticleNumberRand.Size = new System.Drawing.Size(71, 17);
            this.ParticleNumberRand.TabIndex = 2;
            this.ParticleNumberRand.TabStop = false;
            this.ParticleNumberRand.Text = "Random?";
            this.ParticleNumberRand.UseVisualStyleBackColor = true;
            this.ParticleNumberRand.CheckedChanged += new System.EventHandler(this.ParticleNumberRand_CheckedChanged);
            // 
            // ParticleNumberLabel
            // 
            this.ParticleNumberLabel.AutoSize = true;
            this.ParticleNumberLabel.Location = new System.Drawing.Point(6, 18);
            this.ParticleNumberLabel.Name = "ParticleNumberLabel";
            this.ParticleNumberLabel.Size = new System.Drawing.Size(102, 13);
            this.ParticleNumberLabel.TabIndex = 0;
            this.ParticleNumberLabel.Text = "Number of Particles:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1319, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSavedToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openSavedToolStripMenuItem
            // 
            this.openSavedToolStripMenuItem.Name = "openSavedToolStripMenuItem";
            this.openSavedToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.openSavedToolStripMenuItem.Text = "Open Saved...";
            this.openSavedToolStripMenuItem.Click += new System.EventHandler(this.openSavedToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.loadToolStripMenuItem.Text = "Load Image...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xMLToolStripMenuItem,
            this.binaryToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            // 
            // xMLToolStripMenuItem
            // 
            this.xMLToolStripMenuItem.Name = "xMLToolStripMenuItem";
            this.xMLToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.xMLToolStripMenuItem.Text = "XML";
            this.xMLToolStripMenuItem.Click += new System.EventHandler(this.xMLToolStripMenuItem_Click);
            // 
            // binaryToolStripMenuItem
            // 
            this.binaryToolStripMenuItem.Name = "binaryToolStripMenuItem";
            this.binaryToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.binaryToolStripMenuItem.Text = "Binary";
            this.binaryToolStripMenuItem.Click += new System.EventHandler(this.binaryToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeyDisplayString = "Alt-F4";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundColorToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // backgroundColorToolStripMenuItem
            // 
            this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
            this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.backgroundColorToolStripMenuItem.Text = "Background Color...";
            this.backgroundColorToolStripMenuItem.Click += new System.EventHandler(this.backgroundColorToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 744);
            this.Controls.Add(this.EmitterControlsGroup);
            this.Controls.Add(this.DXPanel);
            this.Controls.Add(this.ParticleControlsGroup);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ParticleEditor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.EmitterControlsGroup.ResumeLayout(false);
            this.EmitterControlsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmitterSizeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmitterSizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmitterPositionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmitterDirectionEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmitterPositionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmitterDirectionBegin)).EndInit();
            this.ParticleControlsGroup.ResumeLayout(false);
            this.ParticleControlsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleLifetimeEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleLifetimeBegin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleAccelerationX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleAccelerationY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleSizeBegin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleSizeEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorEndRedBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorEndGreenBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorEndBlueBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorEndAlphaBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorBeginAlphaBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorBeginBlueBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorBeginGreenBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorBeginRedBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorEndAlphaTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorEndBlueTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorEndGreenTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorEndRedTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorBeginAlphaTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorBeginBlueTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorBeginGreenTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleColorBeginRedTrack)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.Panel DXPanel;
		private System.Windows.Forms.GroupBox EmitterControlsGroup;
        private System.Windows.Forms.Label EmitterDirectionBeginLabel;
		private System.Windows.Forms.Label EmitterDirectionLabel;
		private System.Windows.Forms.Label EmitterPositionYLabel;
        private System.Windows.Forms.Label EmitterPositionXLabel;
        private System.Windows.Forms.Label EmitterPositionLabel;
		private System.Windows.Forms.Label EmitterSizeLabel;
		private System.Windows.Forms.Label EmitterDirectionEndLabel;
        private System.Windows.Forms.Label EmitterSizeLabelY;
        private System.Windows.Forms.Label EmitterSizeXLabel;
		private System.Windows.Forms.GroupBox ParticleControlsGroup;
        private System.Windows.Forms.Label ParticleNumberLabel;
        private System.Windows.Forms.Label ParticleSpeedLabel;
		private System.Windows.Forms.CheckBox ParticleLifetimeRand;
        private System.Windows.Forms.Label ParticleLifetimeLabel;
        private System.Windows.Forms.CheckBox ParticleNumberRand;
		private System.Windows.Forms.CheckBox ParticleSpeedRandom;
		private System.Windows.Forms.CheckBox ParticleSpeedConstant;
        private System.Windows.Forms.Label ParticleAccelerationLabel;
		private System.Windows.Forms.Label ParticleAccelerationYLabel;
		private System.Windows.Forms.Label ParticleAccelerationXLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.CheckBox ParticleAccelerationRandom;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.CheckBox ParticleSizeConstant;
		private System.Windows.Forms.Label ParticleSizeLabel;
		private System.Windows.Forms.Label ParticleSizeBeginLabel;
        private System.Windows.Forms.Label ParticleSizeEndLabel;
        private System.Windows.Forms.CheckBox ParticleSizeEndRandom;
        private System.Windows.Forms.CheckBox ParticleSizeBeginRandom;
		private System.Windows.Forms.Label ParticleColorBeginLabel;
        private System.Windows.Forms.TrackBar ParticleColorBeginBlueTrack;
        private System.Windows.Forms.TrackBar ParticleColorBeginGreenTrack;
        private System.Windows.Forms.TrackBar ParticleColorBeginRedTrack;
        private System.Windows.Forms.TrackBar ParticleColorEndAlphaTrack;
        private System.Windows.Forms.TrackBar ParticleColorEndBlueTrack;
        private System.Windows.Forms.TrackBar ParticleColorEndGreenTrack;
        private System.Windows.Forms.TrackBar ParticleColorEndRedTrack;
		private System.Windows.Forms.Label ParticleColorEndLabel;
		private System.Windows.Forms.TrackBar ParticleColorBeginAlphaTrack;
		private System.Windows.Forms.CheckBox ParticleColorConstant;
        private System.Windows.Forms.Label ParticleColorLabel;
        private System.Windows.Forms.CheckBox ParticleColorBeginAlphaRand;
        private System.Windows.Forms.CheckBox ParticleColorBeginBlueRand;
        private System.Windows.Forms.CheckBox ParticleColorBeginGreenRand;
        private System.Windows.Forms.CheckBox ParticleColorBeginRedRand;
        private System.Windows.Forms.Label ParticleColorEndRandLabel;
        private System.Windows.Forms.Label ParticleColorBeginRandLabel;
        private System.Windows.Forms.Label ParticleColorAlphaLabel;
        private System.Windows.Forms.Label ParticleColorBlueLabel;
        private System.Windows.Forms.Label ParticleColorGreenLabel;
        private System.Windows.Forms.Label ParticleColorRedLabel;
        private System.Windows.Forms.CheckBox ParticleColorEndAlphaRand;
        private System.Windows.Forms.CheckBox ParticleColorEndBlueRand;
        private System.Windows.Forms.CheckBox ParticleColorEndGreenRand;
		private System.Windows.Forms.CheckBox ParticleColorEndRedRand;
        private System.Windows.Forms.ToolStripMenuItem openSavedToolStripMenuItem;
        private System.Windows.Forms.Label ParticleSpeedConstantLabel;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.NumericUpDown EmitterPositionX;
		private System.Windows.Forms.NumericUpDown ParticleColorBeginRedBox;
		private System.Windows.Forms.NumericUpDown ParticleColorBeginGreenBox;
		private System.Windows.Forms.NumericUpDown ParticleColorEndRedBox;
		private System.Windows.Forms.NumericUpDown ParticleColorEndGreenBox;
		private System.Windows.Forms.NumericUpDown ParticleColorEndBlueBox;
		private System.Windows.Forms.NumericUpDown ParticleColorEndAlphaBox;
		private System.Windows.Forms.NumericUpDown ParticleColorBeginAlphaBox;
		private System.Windows.Forms.NumericUpDown ParticleColorBeginBlueBox;
		private System.Windows.Forms.NumericUpDown ParticleSpeed;
		private System.Windows.Forms.NumericUpDown EmitterDirectionEnd;
		private System.Windows.Forms.NumericUpDown ParticleLifetimeBegin;
		private System.Windows.Forms.NumericUpDown EmitterDirectionBegin;
		private System.Windows.Forms.NumericUpDown ParticleNumber;
		private System.Windows.Forms.NumericUpDown EmitterPositionY;
		private System.Windows.Forms.NumericUpDown EmitterSizeX;
		private System.Windows.Forms.NumericUpDown EmitterSizeY;
		private System.Windows.Forms.NumericUpDown ParticleAccelerationX;
		private System.Windows.Forms.NumericUpDown ParticleAccelerationY;
		private System.Windows.Forms.NumericUpDown ParticleSizeBegin;
		private System.Windows.Forms.NumericUpDown ParticleSizeEnd;
		private System.Windows.Forms.CheckBox CheckAllRand;
		private System.Windows.Forms.Label ParticleMiliseconds;
		private System.Windows.Forms.NumericUpDown ParticleLifetimeEnd;
		private System.Windows.Forms.Label ParticleLifetimeTo;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem backgroundColorToolStripMenuItem;
		private System.Windows.Forms.ColorDialog BGColor;
		private System.Windows.Forms.Button RandomizeButton;
		private System.Windows.Forms.CheckBox EmitterDirectionRand;
		private System.Windows.Forms.ToolStripMenuItem xMLToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem binaryToolStripMenuItem;
		private System.Windows.Forms.CheckBox EmitterPositionRand;
		private System.Windows.Forms.CheckBox EmitterSizeRand;
		private System.Windows.Forms.CheckBox CheckAllColorRand;
    }
}

