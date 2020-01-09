namespace DS_Gadget
{
    partial class GadgetTabGraphics
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.GroupBox gbxFilter;
            System.Windows.Forms.Label lblHue;
            System.Windows.Forms.Label lblSaturation;
            System.Windows.Forms.Label lblContrast;
            System.Windows.Forms.Label lblBrightness;
            System.Windows.Forms.GroupBox gbxHUD;
            System.Windows.Forms.GroupBox gbxRender;
            this.nudHue = new System.Windows.Forms.NumericUpDown();
            this.nudSaturation = new System.Windows.Forms.NumericUpDown();
            this.cbxContrastSync = new System.Windows.Forms.CheckBox();
            this.nudContrastB = new System.Windows.Forms.NumericUpDown();
            this.nudContrastG = new System.Windows.Forms.NumericUpDown();
            this.nudContrastR = new System.Windows.Forms.NumericUpDown();
            this.cbxBrightnessSync = new System.Windows.Forms.CheckBox();
            this.nudBrightnessB = new System.Windows.Forms.NumericUpDown();
            this.nudBrightnessG = new System.Windows.Forms.NumericUpDown();
            this.nudBrightnessR = new System.Windows.Forms.NumericUpDown();
            this.cbxFilter = new System.Windows.Forms.CheckBox();
            this.cbxNodes = new System.Windows.Forms.CheckBox();
            this.cbxAltimeter = new System.Windows.Forms.CheckBox();
            this.cbxCompassLarge = new System.Windows.Forms.CheckBox();
            this.cbxBounding = new System.Windows.Forms.CheckBox();
            this.cbxCompassSmall = new System.Windows.Forms.CheckBox();
            this.cbxSFX = new System.Windows.Forms.CheckBox();
            this.cbxObjects = new System.Windows.Forms.CheckBox();
            this.cbxSpriteShadows = new System.Windows.Forms.CheckBox();
            this.cbxCreatures = new System.Windows.Forms.CheckBox();
            this.cbxMap = new System.Windows.Forms.CheckBox();
            this.cbxSpriteMasks = new System.Windows.Forms.CheckBox();
            this.cbxDrawTrans = new System.Windows.Forms.CheckBox();
            this.cbxShadows = new System.Windows.Forms.CheckBox();
            this.cbxTextures = new System.Windows.Forms.CheckBox();
            this.cbxSprites = new System.Windows.Forms.CheckBox();
            gbxFilter = new System.Windows.Forms.GroupBox();
            lblHue = new System.Windows.Forms.Label();
            lblSaturation = new System.Windows.Forms.Label();
            lblContrast = new System.Windows.Forms.Label();
            lblBrightness = new System.Windows.Forms.Label();
            gbxHUD = new System.Windows.Forms.GroupBox();
            gbxRender = new System.Windows.Forms.GroupBox();
            gbxFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContrastB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContrastG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContrastR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrightnessB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrightnessG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrightnessR)).BeginInit();
            gbxHUD.SuspendLayout();
            gbxRender.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxFilter
            // 
            gbxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gbxFilter.AutoSize = true;
            gbxFilter.Controls.Add(lblHue);
            gbxFilter.Controls.Add(this.nudHue);
            gbxFilter.Controls.Add(this.nudSaturation);
            gbxFilter.Controls.Add(lblSaturation);
            gbxFilter.Controls.Add(this.cbxContrastSync);
            gbxFilter.Controls.Add(this.nudContrastB);
            gbxFilter.Controls.Add(lblContrast);
            gbxFilter.Controls.Add(this.nudContrastG);
            gbxFilter.Controls.Add(this.nudContrastR);
            gbxFilter.Controls.Add(this.cbxBrightnessSync);
            gbxFilter.Controls.Add(this.nudBrightnessB);
            gbxFilter.Controls.Add(lblBrightness);
            gbxFilter.Controls.Add(this.nudBrightnessG);
            gbxFilter.Controls.Add(this.nudBrightnessR);
            gbxFilter.Controls.Add(this.cbxFilter);
            gbxFilter.Location = new System.Drawing.Point(4, 353);
            gbxFilter.Margin = new System.Windows.Forms.Padding(4);
            gbxFilter.Name = "gbxFilter";
            gbxFilter.Padding = new System.Windows.Forms.Padding(4);
            gbxFilter.Size = new System.Drawing.Size(428, 254);
            gbxFilter.TabIndex = 11;
            gbxFilter.TabStop = false;
            gbxFilter.Text = "Filter";
            // 
            // lblHue
            // 
            lblHue.AutoSize = true;
            lblHue.Location = new System.Drawing.Point(288, 174);
            lblHue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblHue.Name = "lblHue";
            lblHue.Size = new System.Drawing.Size(34, 17);
            lblHue.TabIndex = 15;
            lblHue.Text = "Hue";
            // 
            // nudHue
            // 
            this.nudHue.DecimalPlaces = 3;
            this.nudHue.Location = new System.Drawing.Point(288, 201);
            this.nudHue.Margin = new System.Windows.Forms.Padding(4);
            this.nudHue.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudHue.Name = "nudHue";
            this.nudHue.Size = new System.Drawing.Size(132, 22);
            this.nudHue.TabIndex = 14;
            this.nudHue.ValueChanged += new System.EventHandler(this.nudHue_ValueChanged);
            // 
            // nudSaturation
            // 
            this.nudSaturation.DecimalPlaces = 3;
            this.nudSaturation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudSaturation.Location = new System.Drawing.Point(8, 201);
            this.nudSaturation.Margin = new System.Windows.Forms.Padding(4);
            this.nudSaturation.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudSaturation.Name = "nudSaturation";
            this.nudSaturation.Size = new System.Drawing.Size(132, 22);
            this.nudSaturation.TabIndex = 12;
            this.nudSaturation.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSaturation.ValueChanged += new System.EventHandler(this.nudSaturation_ValueChanged);
            // 
            // lblSaturation
            // 
            lblSaturation.AutoSize = true;
            lblSaturation.Location = new System.Drawing.Point(8, 174);
            lblSaturation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSaturation.Name = "lblSaturation";
            lblSaturation.Size = new System.Drawing.Size(73, 17);
            lblSaturation.TabIndex = 11;
            lblSaturation.Text = "Saturation";
            // 
            // cbxContrastSync
            // 
            this.cbxContrastSync.AutoSize = true;
            this.cbxContrastSync.Checked = true;
            this.cbxContrastSync.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxContrastSync.Location = new System.Drawing.Point(148, 112);
            this.cbxContrastSync.Margin = new System.Windows.Forms.Padding(4);
            this.cbxContrastSync.Name = "cbxContrastSync";
            this.cbxContrastSync.Size = new System.Drawing.Size(108, 21);
            this.cbxContrastSync.TabIndex = 10;
            this.cbxContrastSync.Text = "Synchronize";
            this.cbxContrastSync.UseVisualStyleBackColor = true;
            this.cbxContrastSync.CheckedChanged += new System.EventHandler(this.cbxContrastSync_CheckedChanged);
            // 
            // nudContrastB
            // 
            this.nudContrastB.DecimalPlaces = 3;
            this.nudContrastB.Enabled = false;
            this.nudContrastB.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudContrastB.Location = new System.Drawing.Point(288, 140);
            this.nudContrastB.Margin = new System.Windows.Forms.Padding(4);
            this.nudContrastB.Name = "nudContrastB";
            this.nudContrastB.Size = new System.Drawing.Size(132, 22);
            this.nudContrastB.TabIndex = 9;
            this.nudContrastB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudContrastB.ValueChanged += new System.EventHandler(this.nudContrastB_ValueChanged);
            // 
            // lblContrast
            // 
            lblContrast.AutoSize = true;
            lblContrast.Location = new System.Drawing.Point(8, 113);
            lblContrast.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblContrast.Name = "lblContrast";
            lblContrast.Size = new System.Drawing.Size(105, 17);
            lblContrast.TabIndex = 8;
            lblContrast.Text = "Contrast (RGB)";
            // 
            // nudContrastG
            // 
            this.nudContrastG.DecimalPlaces = 3;
            this.nudContrastG.Enabled = false;
            this.nudContrastG.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudContrastG.Location = new System.Drawing.Point(148, 140);
            this.nudContrastG.Margin = new System.Windows.Forms.Padding(4);
            this.nudContrastG.Name = "nudContrastG";
            this.nudContrastG.Size = new System.Drawing.Size(132, 22);
            this.nudContrastG.TabIndex = 7;
            this.nudContrastG.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudContrastG.ValueChanged += new System.EventHandler(this.nudContrastG_ValueChanged);
            // 
            // nudContrastR
            // 
            this.nudContrastR.DecimalPlaces = 3;
            this.nudContrastR.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudContrastR.Location = new System.Drawing.Point(8, 140);
            this.nudContrastR.Margin = new System.Windows.Forms.Padding(4);
            this.nudContrastR.Name = "nudContrastR";
            this.nudContrastR.Size = new System.Drawing.Size(132, 22);
            this.nudContrastR.TabIndex = 6;
            this.nudContrastR.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudContrastR.ValueChanged += new System.EventHandler(this.nudContrastR_ValueChanged);
            // 
            // cbxBrightnessSync
            // 
            this.cbxBrightnessSync.AutoSize = true;
            this.cbxBrightnessSync.Checked = true;
            this.cbxBrightnessSync.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxBrightnessSync.Location = new System.Drawing.Point(148, 52);
            this.cbxBrightnessSync.Margin = new System.Windows.Forms.Padding(4);
            this.cbxBrightnessSync.Name = "cbxBrightnessSync";
            this.cbxBrightnessSync.Size = new System.Drawing.Size(108, 21);
            this.cbxBrightnessSync.TabIndex = 5;
            this.cbxBrightnessSync.Text = "Synchronize";
            this.cbxBrightnessSync.UseVisualStyleBackColor = true;
            this.cbxBrightnessSync.CheckedChanged += new System.EventHandler(this.cbxBrightnessSync_CheckedChanged);
            // 
            // nudBrightnessB
            // 
            this.nudBrightnessB.DecimalPlaces = 3;
            this.nudBrightnessB.Enabled = false;
            this.nudBrightnessB.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudBrightnessB.Location = new System.Drawing.Point(288, 80);
            this.nudBrightnessB.Margin = new System.Windows.Forms.Padding(4);
            this.nudBrightnessB.Name = "nudBrightnessB";
            this.nudBrightnessB.Size = new System.Drawing.Size(132, 22);
            this.nudBrightnessB.TabIndex = 4;
            this.nudBrightnessB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBrightnessB.ValueChanged += new System.EventHandler(this.nudBrightnessB_ValueChanged);
            // 
            // lblBrightness
            // 
            lblBrightness.AutoSize = true;
            lblBrightness.Location = new System.Drawing.Point(8, 52);
            lblBrightness.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblBrightness.Name = "lblBrightness";
            lblBrightness.Size = new System.Drawing.Size(119, 17);
            lblBrightness.TabIndex = 3;
            lblBrightness.Text = "Brightness (RGB)";
            // 
            // nudBrightnessG
            // 
            this.nudBrightnessG.DecimalPlaces = 3;
            this.nudBrightnessG.Enabled = false;
            this.nudBrightnessG.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudBrightnessG.Location = new System.Drawing.Point(148, 80);
            this.nudBrightnessG.Margin = new System.Windows.Forms.Padding(4);
            this.nudBrightnessG.Name = "nudBrightnessG";
            this.nudBrightnessG.Size = new System.Drawing.Size(132, 22);
            this.nudBrightnessG.TabIndex = 2;
            this.nudBrightnessG.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBrightnessG.ValueChanged += new System.EventHandler(this.nudBrightnessG_ValueChanged);
            // 
            // nudBrightnessR
            // 
            this.nudBrightnessR.DecimalPlaces = 3;
            this.nudBrightnessR.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudBrightnessR.Location = new System.Drawing.Point(8, 80);
            this.nudBrightnessR.Margin = new System.Windows.Forms.Padding(4);
            this.nudBrightnessR.Name = "nudBrightnessR";
            this.nudBrightnessR.Size = new System.Drawing.Size(132, 22);
            this.nudBrightnessR.TabIndex = 1;
            this.nudBrightnessR.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBrightnessR.ValueChanged += new System.EventHandler(this.nudBrightnessR_ValueChanged);
            // 
            // cbxFilter
            // 
            this.cbxFilter.AutoSize = true;
            this.cbxFilter.Location = new System.Drawing.Point(8, 23);
            this.cbxFilter.Margin = new System.Windows.Forms.Padding(4);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.Size = new System.Drawing.Size(120, 21);
            this.cbxFilter.TabIndex = 0;
            this.cbxFilter.Text = "Override Filter";
            this.cbxFilter.UseVisualStyleBackColor = true;
            this.cbxFilter.CheckedChanged += new System.EventHandler(this.cbxFilter_CheckedChanged);
            // 
            // gbxHUD
            // 
            gbxHUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gbxHUD.AutoSize = true;
            gbxHUD.Controls.Add(this.cbxNodes);
            gbxHUD.Controls.Add(this.cbxAltimeter);
            gbxHUD.Controls.Add(this.cbxCompassLarge);
            gbxHUD.Controls.Add(this.cbxBounding);
            gbxHUD.Controls.Add(this.cbxCompassSmall);
            gbxHUD.Location = new System.Drawing.Point(4, 221);
            gbxHUD.Margin = new System.Windows.Forms.Padding(4);
            gbxHUD.Name = "gbxHUD";
            gbxHUD.Padding = new System.Windows.Forms.Padding(4);
            gbxHUD.Size = new System.Drawing.Size(428, 124);
            gbxHUD.TabIndex = 10;
            gbxHUD.TabStop = false;
            gbxHUD.Text = "Debug";
            // 
            // cbxNodes
            // 
            this.cbxNodes.AutoSize = true;
            this.cbxNodes.Location = new System.Drawing.Point(148, 23);
            this.cbxNodes.Margin = new System.Windows.Forms.Padding(4);
            this.cbxNodes.Name = "cbxNodes";
            this.cbxNodes.Size = new System.Drawing.Size(108, 21);
            this.cbxNodes.TabIndex = 11;
            this.cbxNodes.Text = "Node Graph";
            this.cbxNodes.UseVisualStyleBackColor = true;
            this.cbxNodes.CheckedChanged += new System.EventHandler(this.cbxNodes_CheckedChanged);
            // 
            // cbxAltimeter
            // 
            this.cbxAltimeter.AutoSize = true;
            this.cbxAltimeter.Location = new System.Drawing.Point(8, 80);
            this.cbxAltimeter.Margin = new System.Windows.Forms.Padding(4);
            this.cbxAltimeter.Name = "cbxAltimeter";
            this.cbxAltimeter.Size = new System.Drawing.Size(85, 21);
            this.cbxAltimeter.TabIndex = 10;
            this.cbxAltimeter.Text = "Altimeter";
            this.cbxAltimeter.UseVisualStyleBackColor = true;
            this.cbxAltimeter.CheckedChanged += new System.EventHandler(this.cbxAltimeter_CheckedChanged);
            // 
            // cbxCompassLarge
            // 
            this.cbxCompassLarge.AutoSize = true;
            this.cbxCompassLarge.Location = new System.Drawing.Point(8, 23);
            this.cbxCompassLarge.Margin = new System.Windows.Forms.Padding(4);
            this.cbxCompassLarge.Name = "cbxCompassLarge";
            this.cbxCompassLarge.Size = new System.Drawing.Size(129, 21);
            this.cbxCompassLarge.TabIndex = 8;
            this.cbxCompassLarge.Text = "Large Compass";
            this.cbxCompassLarge.UseVisualStyleBackColor = true;
            this.cbxCompassLarge.CheckedChanged += new System.EventHandler(this.cbxCompassLarge_CheckedChanged);
            // 
            // cbxBounding
            // 
            this.cbxBounding.AutoSize = true;
            this.cbxBounding.Location = new System.Drawing.Point(148, 52);
            this.cbxBounding.Margin = new System.Windows.Forms.Padding(4);
            this.cbxBounding.Name = "cbxBounding";
            this.cbxBounding.Size = new System.Drawing.Size(132, 21);
            this.cbxBounding.TabIndex = 0;
            this.cbxBounding.Text = "Bounding Boxes";
            this.cbxBounding.UseVisualStyleBackColor = true;
            this.cbxBounding.CheckedChanged += new System.EventHandler(this.cbxBounding_CheckedChanged);
            // 
            // cbxCompassSmall
            // 
            this.cbxCompassSmall.AutoSize = true;
            this.cbxCompassSmall.Location = new System.Drawing.Point(8, 52);
            this.cbxCompassSmall.Margin = new System.Windows.Forms.Padding(4);
            this.cbxCompassSmall.Name = "cbxCompassSmall";
            this.cbxCompassSmall.Size = new System.Drawing.Size(126, 21);
            this.cbxCompassSmall.TabIndex = 9;
            this.cbxCompassSmall.Text = "Small Compass";
            this.cbxCompassSmall.UseVisualStyleBackColor = true;
            this.cbxCompassSmall.CheckedChanged += new System.EventHandler(this.cbxCompassSmall_CheckedChanged);
            // 
            // gbxRender
            // 
            gbxRender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gbxRender.AutoSize = true;
            gbxRender.Controls.Add(this.cbxSFX);
            gbxRender.Controls.Add(this.cbxObjects);
            gbxRender.Controls.Add(this.cbxSpriteShadows);
            gbxRender.Controls.Add(this.cbxCreatures);
            gbxRender.Controls.Add(this.cbxMap);
            gbxRender.Controls.Add(this.cbxSpriteMasks);
            gbxRender.Controls.Add(this.cbxDrawTrans);
            gbxRender.Controls.Add(this.cbxShadows);
            gbxRender.Controls.Add(this.cbxTextures);
            gbxRender.Controls.Add(this.cbxSprites);
            gbxRender.Location = new System.Drawing.Point(4, 4);
            gbxRender.Margin = new System.Windows.Forms.Padding(4);
            gbxRender.Name = "gbxRender";
            gbxRender.Padding = new System.Windows.Forms.Padding(4);
            gbxRender.Size = new System.Drawing.Size(428, 209);
            gbxRender.TabIndex = 9;
            gbxRender.TabStop = false;
            gbxRender.Text = "Render";
            // 
            // cbxSFX
            // 
            this.cbxSFX.AutoSize = true;
            this.cbxSFX.Checked = true;
            this.cbxSFX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxSFX.Location = new System.Drawing.Point(8, 108);
            this.cbxSFX.Margin = new System.Windows.Forms.Padding(4);
            this.cbxSFX.Name = "cbxSFX";
            this.cbxSFX.Size = new System.Drawing.Size(56, 21);
            this.cbxSFX.TabIndex = 12;
            this.cbxSFX.Text = "SFX";
            this.cbxSFX.UseVisualStyleBackColor = true;
            this.cbxSFX.CheckedChanged += new System.EventHandler(this.cbxSFX_CheckedChanged);
            // 
            // cbxObjects
            // 
            this.cbxObjects.AutoSize = true;
            this.cbxObjects.Checked = true;
            this.cbxObjects.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxObjects.Location = new System.Drawing.Point(8, 80);
            this.cbxObjects.Margin = new System.Windows.Forms.Padding(4);
            this.cbxObjects.Name = "cbxObjects";
            this.cbxObjects.Size = new System.Drawing.Size(78, 21);
            this.cbxObjects.TabIndex = 11;
            this.cbxObjects.Text = "Objects";
            this.cbxObjects.UseVisualStyleBackColor = true;
            this.cbxObjects.CheckedChanged += new System.EventHandler(this.cbxObjects_CheckedChanged);
            // 
            // cbxSpriteShadows
            // 
            this.cbxSpriteShadows.AutoSize = true;
            this.cbxSpriteShadows.Checked = true;
            this.cbxSpriteShadows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxSpriteShadows.Location = new System.Drawing.Point(148, 52);
            this.cbxSpriteShadows.Margin = new System.Windows.Forms.Padding(4);
            this.cbxSpriteShadows.Name = "cbxSpriteShadows";
            this.cbxSpriteShadows.Size = new System.Drawing.Size(128, 21);
            this.cbxSpriteShadows.TabIndex = 10;
            this.cbxSpriteShadows.Text = "Sprite Shadows";
            this.cbxSpriteShadows.UseVisualStyleBackColor = true;
            this.cbxSpriteShadows.CheckedChanged += new System.EventHandler(this.cbxSpriteShadows_CheckedChanged);
            // 
            // cbxCreatures
            // 
            this.cbxCreatures.AutoSize = true;
            this.cbxCreatures.Checked = true;
            this.cbxCreatures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxCreatures.Location = new System.Drawing.Point(8, 52);
            this.cbxCreatures.Margin = new System.Windows.Forms.Padding(4);
            this.cbxCreatures.Name = "cbxCreatures";
            this.cbxCreatures.Size = new System.Drawing.Size(92, 21);
            this.cbxCreatures.TabIndex = 9;
            this.cbxCreatures.Text = "Creatures";
            this.cbxCreatures.UseVisualStyleBackColor = true;
            this.cbxCreatures.CheckedChanged += new System.EventHandler(this.cbxCreatures_CheckedChanged);
            // 
            // cbxMap
            // 
            this.cbxMap.AutoSize = true;
            this.cbxMap.Checked = true;
            this.cbxMap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxMap.Location = new System.Drawing.Point(8, 23);
            this.cbxMap.Margin = new System.Windows.Forms.Padding(4);
            this.cbxMap.Name = "cbxMap";
            this.cbxMap.Size = new System.Drawing.Size(57, 21);
            this.cbxMap.TabIndex = 8;
            this.cbxMap.Text = "Map";
            this.cbxMap.UseVisualStyleBackColor = true;
            this.cbxMap.CheckedChanged += new System.EventHandler(this.cbxMap_CheckedChanged);
            // 
            // cbxSpriteMasks
            // 
            this.cbxSpriteMasks.AutoSize = true;
            this.cbxSpriteMasks.Checked = true;
            this.cbxSpriteMasks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxSpriteMasks.Location = new System.Drawing.Point(148, 137);
            this.cbxSpriteMasks.Margin = new System.Windows.Forms.Padding(4);
            this.cbxSpriteMasks.Name = "cbxSpriteMasks";
            this.cbxSpriteMasks.Size = new System.Drawing.Size(202, 21);
            this.cbxSpriteMasks.TabIndex = 1;
            this.cbxSpriteMasks.Text = "DepthDraw_DepthTexEdge";
            this.cbxSpriteMasks.UseVisualStyleBackColor = true;
            this.cbxSpriteMasks.CheckedChanged += new System.EventHandler(this.cbxSpriteMasks_CheckedChanged);
            // 
            // cbxDrawTrans
            // 
            this.cbxDrawTrans.AutoSize = true;
            this.cbxDrawTrans.Checked = true;
            this.cbxDrawTrans.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxDrawTrans.Location = new System.Drawing.Point(148, 165);
            this.cbxDrawTrans.Margin = new System.Windows.Forms.Padding(4);
            this.cbxDrawTrans.Name = "cbxDrawTrans";
            this.cbxDrawTrans.Size = new System.Drawing.Size(152, 21);
            this.cbxDrawTrans.TabIndex = 3;
            this.cbxDrawTrans.Text = "NormalDraw_Trans";
            this.cbxDrawTrans.UseVisualStyleBackColor = true;
            this.cbxDrawTrans.CheckedChanged += new System.EventHandler(this.cbxDrawTrans_CheckedChanged);
            // 
            // cbxShadows
            // 
            this.cbxShadows.AutoSize = true;
            this.cbxShadows.Checked = true;
            this.cbxShadows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxShadows.Location = new System.Drawing.Point(148, 23);
            this.cbxShadows.Margin = new System.Windows.Forms.Padding(4);
            this.cbxShadows.Name = "cbxShadows";
            this.cbxShadows.Size = new System.Drawing.Size(87, 21);
            this.cbxShadows.TabIndex = 4;
            this.cbxShadows.Text = "Shadows";
            this.cbxShadows.UseVisualStyleBackColor = true;
            this.cbxShadows.CheckedChanged += new System.EventHandler(this.cbxShadows_CheckedChanged);
            // 
            // cbxTextures
            // 
            this.cbxTextures.AutoSize = true;
            this.cbxTextures.Checked = true;
            this.cbxTextures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxTextures.Location = new System.Drawing.Point(148, 80);
            this.cbxTextures.Margin = new System.Windows.Forms.Padding(4);
            this.cbxTextures.Name = "cbxTextures";
            this.cbxTextures.Size = new System.Drawing.Size(85, 21);
            this.cbxTextures.TabIndex = 5;
            this.cbxTextures.Text = "Textures";
            this.cbxTextures.UseVisualStyleBackColor = true;
            this.cbxTextures.CheckedChanged += new System.EventHandler(this.cbxTextures_CheckedChanged);
            // 
            // cbxSprites
            // 
            this.cbxSprites.AutoSize = true;
            this.cbxSprites.Checked = true;
            this.cbxSprites.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxSprites.Location = new System.Drawing.Point(148, 108);
            this.cbxSprites.Margin = new System.Windows.Forms.Padding(4);
            this.cbxSprites.Name = "cbxSprites";
            this.cbxSprites.Size = new System.Drawing.Size(171, 21);
            this.cbxSprites.TabIndex = 2;
            this.cbxSprites.Text = "NormalDraw_TexEdge";
            this.cbxSprites.UseVisualStyleBackColor = true;
            this.cbxSprites.CheckedChanged += new System.EventHandler(this.cbxSprites_CheckedChanged);
            // 
            // GadgetTabGraphics
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.Controls.Add(gbxFilter);
            this.Controls.Add(gbxHUD);
            this.Controls.Add(gbxRender);
            this.Name = "GadgetTabGraphics";
            this.Size = new System.Drawing.Size(436, 611);
            gbxFilter.ResumeLayout(false);
            gbxFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContrastB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContrastG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContrastR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrightnessB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrightnessG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrightnessR)).EndInit();
            gbxHUD.ResumeLayout(false);
            gbxHUD.PerformLayout();
            gbxRender.ResumeLayout(false);
            gbxRender.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudHue;
        private System.Windows.Forms.NumericUpDown nudSaturation;
        private System.Windows.Forms.CheckBox cbxContrastSync;
        private System.Windows.Forms.NumericUpDown nudContrastB;
        private System.Windows.Forms.NumericUpDown nudContrastG;
        private System.Windows.Forms.NumericUpDown nudContrastR;
        private System.Windows.Forms.CheckBox cbxBrightnessSync;
        private System.Windows.Forms.NumericUpDown nudBrightnessB;
        private System.Windows.Forms.NumericUpDown nudBrightnessG;
        private System.Windows.Forms.NumericUpDown nudBrightnessR;
        private System.Windows.Forms.CheckBox cbxFilter;
        private System.Windows.Forms.CheckBox cbxNodes;
        private System.Windows.Forms.CheckBox cbxAltimeter;
        private System.Windows.Forms.CheckBox cbxCompassLarge;
        private System.Windows.Forms.CheckBox cbxBounding;
        private System.Windows.Forms.CheckBox cbxCompassSmall;
        private System.Windows.Forms.CheckBox cbxSFX;
        private System.Windows.Forms.CheckBox cbxObjects;
        private System.Windows.Forms.CheckBox cbxSpriteShadows;
        private System.Windows.Forms.CheckBox cbxCreatures;
        private System.Windows.Forms.CheckBox cbxMap;
        private System.Windows.Forms.CheckBox cbxSpriteMasks;
        private System.Windows.Forms.CheckBox cbxDrawTrans;
        private System.Windows.Forms.CheckBox cbxShadows;
        private System.Windows.Forms.CheckBox cbxTextures;
        private System.Windows.Forms.CheckBox cbxSprites;
    }
}
