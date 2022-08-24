using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ns0;
using ns5;

namespace ns2
{
	[ToolboxItem(false)]
	public class GradientCircleButton : CustomButtonBase
	{
		private int int_3 = 0;

		private GraphicsPath graphicsPath_0;

		private ButtonImages buttonImages_0;

		private GradientButtonState gradientButtonState_0;

		private GradientButtonState gradientButtonState_1;

		private LinearGradientMode linearGradientMode_0 = LinearGradientMode.Horizontal;

		private Color color_5 = Class0.color_25;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected ButtonImages DefaultCustomImages
		{
			get
			{
				if (this.buttonImages_0 == null)
				{
					this.buttonImages_0 = new ButtonImages
					{
						Parent = this
					};
				}
				return this.buttonImages_0;
			}
			set
			{
				this.buttonImages_0 = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected GradientButtonState DefaultHoveredState
		{
			get
			{
				if (this.gradientButtonState_0 == null)
				{
					this.gradientButtonState_0 = new GradientButtonState
					{
						Parent = this
					};
				}
				return this.gradientButtonState_0;
			}
			set
			{
				this.gradientButtonState_0 = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected GradientButtonState DefaultCheckedState
		{
			get
			{
				if (this.gradientButtonState_1 == null)
				{
					this.gradientButtonState_1 = new GradientButtonState
					{
						Parent = this
					};
				}
				return this.gradientButtonState_1;
			}
			set
			{
				this.gradientButtonState_1 = value;
			}
		}

		[Browsable(false)]
		protected LinearGradientMode DefaultGradientMode
		{
			get
			{
				return this.linearGradientMode_0;
			}
			set
			{
				this.linearGradientMode_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected Color DefaultFillColor2
		{
			get
			{
				return this.color_5;
			}
			set
			{
				this.color_5 = value;
				base.Invalidate();
			}
		}

		public GradientCircleButton()
		{
			base.DefaultShadowDecoration.Mode = ShadowMode.Circle;
			base.Size = new Size(160, 160);
		}

		private StringAlignment method_5(HorizontalAlignment horizontalAlignment_2)
		{
			return horizontalAlignment_2 switch
			{
				HorizontalAlignment.Left => StringAlignment.Near, 
				HorizontalAlignment.Right => StringAlignment.Far, 
				HorizontalAlignment.Center => StringAlignment.Center, 
				_ => (StringAlignment)horizontalAlignment_2, 
			};
		}

		private Color method_6()
		{
			if (!(this.DefaultHoveredState.FillColor == Color.Empty))
			{
				return this.DefaultHoveredState.FillColor;
			}
			return Class6.smethod_10(base.DefaultFillColor, Color.Black, Color.White, 15);
		}

		private Color method_7()
		{
			if (!(this.DefaultHoveredState.FillColor2 == Color.Empty))
			{
				return this.DefaultHoveredState.FillColor2;
			}
			return Class6.smethod_10(this.DefaultFillColor2, Color.Black, Color.White, 15);
		}

		private Color method_8()
		{
			if (!(this.DefaultCheckedState.FillColor == Color.Empty))
			{
				return this.DefaultCheckedState.FillColor;
			}
			return this.method_6();
		}

		private Color method_9()
		{
			if (!(this.DefaultCheckedState.FillColor2 == Color.Empty))
			{
				return this.DefaultCheckedState.FillColor2;
			}
			return this.method_7();
		}

		private Color method_10()
		{
			if (!(this.DefaultHoveredState.ForeColor == Color.Empty))
			{
				return this.DefaultHoveredState.ForeColor;
			}
			return base.ForeColor;
		}

		private Color method_11()
		{
			if (!(this.DefaultHoveredState.CustomBorderColor == Color.Empty))
			{
				return this.DefaultHoveredState.CustomBorderColor;
			}
			return Class6.smethod_10(base.DefaultCustomBorderColor, Color.Black, Color.White, 15);
		}

		private Color method_12()
		{
			if (!(this.DefaultHoveredState.BorderColor == Color.Empty))
			{
				return this.DefaultHoveredState.BorderColor;
			}
			return Class6.smethod_10(base.DefaultBorderColor, Color.Black, Color.White, 15);
		}

		private Font method_13()
		{
			if (this.DefaultHoveredState.Font != null)
			{
				return this.DefaultHoveredState.Font;
			}
			return base.Font;
		}

		private Image method_14()
		{
			if (this.DefaultHoveredState.Image != null)
			{
				return this.DefaultHoveredState.Image;
			}
			return base.DefaultImage;
		}

		private Color method_15()
		{
			if (!(this.DefaultCheckedState.ForeColor == Color.Empty))
			{
				return this.DefaultCheckedState.ForeColor;
			}
			return this.method_10();
		}

		private Color method_16()
		{
			if (!(this.DefaultCheckedState.CustomBorderColor == Color.Empty))
			{
				return this.DefaultCheckedState.CustomBorderColor;
			}
			return this.method_11();
		}

		private Color method_17()
		{
			if (!(this.DefaultCheckedState.BorderColor == Color.Empty))
			{
				return this.DefaultCheckedState.BorderColor;
			}
			return this.method_12();
		}

		private Font method_18()
		{
			if (this.DefaultCheckedState.Font != null)
			{
				return this.DefaultCheckedState.Font;
			}
			return this.method_13();
		}

		private Image method_19()
		{
			if (this.DefaultCheckedState.Image != null)
			{
				return this.DefaultCheckedState.Image;
			}
			return this.method_14();
		}

		private Image method_20()
		{
			if (this.DefaultCustomImages.HoveredImage != null)
			{
				return this.DefaultCustomImages.HoveredImage;
			}
			return this.DefaultCustomImages.Image;
		}

		private Image method_21()
		{
			if (this.DefaultCustomImages.CheckedImage != null)
			{
				return this.DefaultCustomImages.CheckedImage;
			}
			return this.method_20();
		}

		private object method_22(Graphics graphics_0)
		{
			int num = base.Width;
			Bitmap bitmap = ((graphics_0 == null) ? new Bitmap(num, base.Height) : null);
			Graphics graphics = ((graphics_0 != null) ? graphics_0 : Graphics.FromImage(bitmap));
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			checked
			{
				int num2 = base.AnimationManager.GetAnimationCount() - 1;
				for (int i = 0; i <= num2; i++)
				{
					double progress = base.AnimationManager.GetProgress(i);
					Point source = base.AnimationManager.GetSource(i);
					using Brush brush = new SolidBrush(Color.FromArgb((int)Math.Round(101.0 - progress * 100.0), base.DefaultPressedColor));
					int num3 = (int)Math.Round(progress * (double)num * 2.0);
					graphics.FillEllipse(brush, new Rectangle((int)Math.Round((double)source.X - (double)num3 / 2.0), (int)Math.Round((double)source.Y - (double)num3 / 2.0), num3, num3));
				}
				return bitmap;
			}
		}

		private void method_23(Graphics graphics_0)
		{
			Color color = base.DefaultFillColor;
			Color color2 = this.DefaultFillColor2;
			Color color3 = base.ForeColor;
			Color color4 = base.DefaultCustomBorderColor;
			Color color5 = base.DefaultBorderColor;
			Font font = base.Font;
			Image image = base.DefaultImage;
			Image image2 = this.DefaultCustomImages.Image;
			if (base.DefaultAnimated && !base.DesignMode)
			{
				color = Class6.smethod_23((int)Math.Round(base.HoveredAnimationManager.GetProgress() * 100.0), color, this.method_6());
				color2 = Class6.smethod_23((int)Math.Round(base.HoveredAnimationManager.GetProgress() * 100.0), color2, this.method_7());
				color3 = Class6.smethod_23((int)Math.Round(base.HoveredAnimationManager.GetProgress() * 100.0), color3, this.method_10());
				color4 = Class6.smethod_23((int)Math.Round(base.HoveredAnimationManager.GetProgress() * 100.0), color4, this.method_11());
				color5 = Class6.smethod_23((int)Math.Round(base.HoveredAnimationManager.GetProgress() * 100.0), color5, this.method_12());
				color = Class6.smethod_23((int)Math.Round(base.CheckedAnimationManager.GetProgress() * 100.0), color, this.method_8());
				color2 = Class6.smethod_23((int)Math.Round(base.CheckedAnimationManager.GetProgress() * 100.0), color2, this.method_9());
				color3 = Class6.smethod_23((int)Math.Round(base.CheckedAnimationManager.GetProgress() * 100.0), color3, this.method_15());
				color4 = Class6.smethod_23((int)Math.Round(base.CheckedAnimationManager.GetProgress() * 100.0), color4, this.method_16());
				color5 = Class6.smethod_23((int)Math.Round(base.CheckedAnimationManager.GetProgress() * 100.0), color5, this.method_17());
			}
			else if (base.DefaultChecked)
			{
				color = this.method_8();
				color2 = this.method_9();
				color3 = this.method_15();
				color4 = this.method_16();
				color5 = this.method_17();
			}
			else if ((base.mouseState_0 == MouseState.HOVER) | (base.mouseState_0 == MouseState.DOWN))
			{
				color = this.method_6();
				color2 = this.method_7();
				color3 = this.method_10();
				color4 = this.method_11();
				color5 = this.method_12();
				if ((base.mouseState_0 == MouseState.DOWN) & (base.DefaultPressedDepth > 0))
				{
					color = Class6.smethod_23(base.DefaultPressedDepth, color, base.DefaultPressedColor);
					color2 = Class6.smethod_23(base.DefaultPressedDepth, color2, base.DefaultPressedColor);
					color4 = Class6.smethod_23(base.DefaultPressedDepth, color4, base.DefaultPressedColor);
					color5 = Class6.smethod_23(base.DefaultPressedDepth, color5, base.DefaultPressedColor);
				}
			}
			if (base.DefaultChecked)
			{
				font = this.method_18();
				image = this.method_19();
				image2 = this.method_21();
			}
			else if ((base.mouseState_0 == MouseState.HOVER) | (base.mouseState_0 == MouseState.DOWN))
			{
				font = this.method_13();
				image = this.method_14();
				image2 = this.method_20();
			}
			bool flag = !base.DefaultChecked & base.Enabled & this.Focused & (base.DefaultFocusedColor != Color.Empty) & (base.mouseState_0 == MouseState.const_2);
			using (LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(base.ClientRectangle.X - 1, base.ClientRectangle.Y, base.ClientRectangle.Width + 2, base.ClientRectangle.Height), color, color2, this.DefaultGradientMode))
			{
				this.graphicsPath_0 = new GraphicsPath();
				this.graphicsPath_0.AddEllipse(0, 0, base.Width - 1, base.Height - 1);
				graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
				graphics_0.FillPath(brush, this.graphicsPath_0);
				if (flag | (base.DefaultBorderThickness > 0))
				{
					Class6.smethod_19(graphics_0, flag ? new SolidBrush(base.DefaultFocusedColor) : new SolidBrush(color5), base.ClientRectangle, base.DefaultBorderThickness, base.DefaultBorderStyle);
				}
			}
			Class6.smethod_16(graphics_0, color4, base.ClientRectangle, base.DefaultCustomBorderThickness);
			Rectangle rectangle = new Rectangle(base.DefaultTextOffset.X, base.DefaultTextOffset.Y, base.Width, base.Height);
			int num = (int)graphics_0.MeasureString(this.Text, this.Font).Width;
			if (base.DefaultTextAlign == HorizontalAlignment.Right)
			{
				rectangle.X = -10;
				rectangle.X += base.DefaultTextOffset.X;
			}
			else if (base.DefaultTextAlign == HorizontalAlignment.Left)
			{
				rectangle.X += 10;
			}
			if (image != null)
			{
				Rectangle rect = new Rectangle(base.DefaultImageOffset.X, base.DefaultImageOffset.Y, base.DefaultImageSize.Width, base.DefaultImageSize.Height);
				switch (base.DefaultImageAlign)
				{
				case HorizontalAlignment.Left:
					if (!base.DefaultTile && base.DefaultTextAlign == HorizontalAlignment.Left)
					{
						rectangle.X += base.DefaultImageSize.Width + 5;
					}
					rect.X += 10;
					rect.Y += Class6.smethod_8(base.DefaultImageSize.Height, base.Height);
					break;
				case HorizontalAlignment.Right:
					if (!base.DefaultTile && base.DefaultTextAlign == HorizontalAlignment.Right)
					{
						rectangle.X -= base.DefaultImageSize.Width + 5;
					}
					rect.X = base.Width - (base.DefaultImageSize.Width + rect.X + 10);
					rect.Y += Class6.smethod_8(base.DefaultImageSize.Height, base.Height);
					break;
				case HorizontalAlignment.Center:
					rect.X += Class6.smethod_8(base.DefaultImageSize.Width, base.Width);
					rect.Y += Class6.smethod_8(base.DefaultImageSize.Height, base.Height);
					break;
				}
				if (base.DefaultTile && this.Text != string.Empty)
				{
					int num2 = (int)((float)base.DefaultImageSize.Height + graphics_0.MeasureString(this.Text, this.Font).Height) / 3;
					rect.Y -= num2;
					rectangle.Y += num2;
				}
				else if (base.DefaultTextAlign == HorizontalAlignment.Center && base.DefaultImageAlign == HorizontalAlignment.Center)
				{
					if (base.Width > num)
					{
						rectangle.X += base.DefaultImageSize.Width / 2;
						rectangle.X += base.DefaultTextOffset.X;
						rectangle.X += 2;
						rect.X -= num / 2;
						rect.X--;
						rect.X += base.DefaultImageOffset.X;
					}
					else
					{
						int num3 = (int)((float)base.DefaultImageSize.Height + graphics_0.MeasureString(this.Text, this.Font).Height) / 3;
						rect.Y -= num3;
						rectangle.Y += num3;
					}
				}
				graphics_0.DrawImage(image, rect);
			}
			if (image2 != null)
			{
				Rectangle rect2 = new Rectangle(this.DefaultCustomImages.ImageOffset.X, this.DefaultCustomImages.ImageOffset.Y, this.DefaultCustomImages.ImageSize.Width, this.DefaultCustomImages.ImageSize.Height);
				switch (this.DefaultCustomImages.ImageAlign)
				{
				case HorizontalAlignment.Left:
					rect2.X += 10;
					rect2.Y += Class6.smethod_8(this.DefaultCustomImages.ImageSize.Height, base.Height);
					break;
				case HorizontalAlignment.Right:
					rect2.X = base.Width - (this.DefaultCustomImages.ImageSize.Width + rect2.X + 10);
					rect2.Y += Class6.smethod_8(this.DefaultCustomImages.ImageSize.Height, base.Height);
					break;
				case HorizontalAlignment.Center:
					rect2.X += Class6.smethod_8(this.DefaultCustomImages.ImageSize.Width, base.Width);
					rect2.Y += Class6.smethod_8(base.DefaultImageSize.Height, base.Height);
					break;
				}
				graphics_0.DrawImage(image2, rect2);
			}
			if (base.DefaultTile | (base.Width < num))
			{
				rectangle.X += base.Margin.Left;
				rectangle.Width -= base.Margin.Left + base.Margin.Right;
			}
			graphics_0.TextRenderingHint = base.DefaultTextRenderingHint;
			using (StringFormat format = new StringFormat
			{
				FormatFlags = StringFormatFlags.LineLimit,
				Alignment = this.method_5(base.DefaultTextAlign),
				LineAlignment = StringAlignment.Center
			})
			{
				switch (base.DefaultTextTransform)
				{
				case TextTransform.None:
					graphics_0.DrawString(this.Text, font, new SolidBrush(color3), rectangle, format);
					break;
				case TextTransform.UpperCase:
					graphics_0.DrawString(this.Text.ToUpper(), font, new SolidBrush(color3), rectangle, format);
					break;
				case TextTransform.LowerCase:
					graphics_0.DrawString(this.Text.ToLower(), font, new SolidBrush(color3), rectangle, format);
					break;
				}
			}
			if (base.DefaultAnimated & (base.DefaultPressedDepth != 0) & base.AnimationManager.IsAnimating())
			{
				graphics_0.FillPath(new TextureBrush((Bitmap)this.method_22(null)), this.graphicsPath_0);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (!base.Enabled)
			{
				Bitmap image = new Bitmap(base.Width, base.Height);
				this.method_23(Graphics.FromImage(image));
				ControlPaint.DrawImageDisabled(e.Graphics, image, 0, 0, Color.White);
			}
			else
			{
				this.method_23(e.Graphics);
			}
			base.OnPaint(e);
		}
	}
}
