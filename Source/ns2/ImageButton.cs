using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns0;
using ns5;

namespace ns2
{
	[ToolboxItem(false)]
	public class ImageButton : UIDefaultControl, IButtonControl
	{
		private bool bool_4;

		private DialogResult dialogResult_0;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private EventHandler eventHandler_0;

		private ImageControlState imageControlState_0;

		private ImageControlState imageControlState_1;

		private ImageControlState imageControlState_2;

		private Color color_1;

		private Image image_0;

		private Size size_0;

		private Point point_0;

		private Point point_1;

		private HorizontalAlignment horizontalAlignment_0;

		private HorizontalAlignment horizontalAlignment_1;

		private TextRenderingHint textRenderingHint_0;

		private TextTransform textTransform_0;

		[DefaultValue(0)]
		public DialogResult DialogResult
		{
			get
			{
				return this.dialogResult_0;
			}
			set
			{
				this.dialogResult_0 = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected ImageControlState DefaultHoveredState
		{
			get
			{
				if (this.imageControlState_0 == null)
				{
					this.imageControlState_0 = new ImageControlState
					{
						Parent = this
					};
				}
				return this.imageControlState_0;
			}
			set
			{
				this.imageControlState_0 = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected ImageControlState DefaultCheckedState
		{
			get
			{
				if (this.imageControlState_1 == null)
				{
					this.imageControlState_1 = new ImageControlState
					{
						Parent = this
					};
				}
				return this.imageControlState_1;
			}
			set
			{
				this.imageControlState_1 = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected ImageControlState DefaultPressedState
		{
			get
			{
				if (this.imageControlState_2 == null)
				{
					this.imageControlState_2 = new ImageControlState
					{
						Parent = this
					};
				}
				return this.imageControlState_2;
			}
			set
			{
				this.imageControlState_2 = value;
			}
		}

		[Browsable(false)]
		protected Color DefaultFocusedColor
		{
			get
			{
				return this.color_1;
			}
			set
			{
				this.color_1 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected Image DefaultImage
		{
			get
			{
				return this.image_0;
			}
			set
			{
				this.image_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected Size DefaultImageSize
		{
			get
			{
				return this.size_0;
			}
			set
			{
				this.size_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected Point DefaultImageOffset
		{
			get
			{
				return this.point_0;
			}
			set
			{
				this.point_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected Point DefaultTextOffset
		{
			get
			{
				return this.point_1;
			}
			set
			{
				this.point_1 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected HorizontalAlignment DefaultTextAlign
		{
			get
			{
				return this.horizontalAlignment_0;
			}
			set
			{
				this.horizontalAlignment_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected HorizontalAlignment DefaultImageAlign
		{
			get
			{
				return this.horizontalAlignment_1;
			}
			set
			{
				this.horizontalAlignment_1 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected TextRenderingHint DefaultTextRenderingHint
		{
			get
			{
				return this.textRenderingHint_0;
			}
			set
			{
				this.textRenderingHint_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected TextTransform DefaultTextTransform
		{
			get
			{
				return this.textTransform_0;
			}
			set
			{
				this.textTransform_0 = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		protected bool DefaultChecked
		{
			get
			{
				return this.bool_4;
			}
			set
			{
				this.bool_4 = value;
				this.OnCheckedChanged(EventArgs.Empty);
			}
		}

		public event EventHandler CheckedChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Combine(eventHandler2, value), location1: ref this.eventHandler_0, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					eventHandler = Interlocked.CompareExchange(value: (EventHandler)Delegate.Remove(eventHandler2, value), location1: ref this.eventHandler_0, comparand: eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public ImageButton()
		{
			this.bool_4 = false;
			base.MouseState = MouseState.const_2;
			base.bool_1 = true;
			base.bool_2 = true;
			this.dialogResult_0 = DialogResult.None;
			this.size_0 = new Size(20, 20);
			this.horizontalAlignment_0 = HorizontalAlignment.Center;
			this.horizontalAlignment_1 = HorizontalAlignment.Center;
			this.textRenderingHint_0 = TextRenderingHint.ClearTypeGridFit;
		}

		public void NotifyDefault(bool value)
		{
		}

		public void PerformClick()
		{
			this.OnClick(EventArgs.Empty);
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnCheckedChanged(EventArgs e)
		{
			base.Invalidate();
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, EventArgs.Empty);
			}
		}

		protected override void OnKeyDown(KeyEventArgs kevent)
		{
			if ((kevent.KeyData == Keys.Space) | (kevent.KeyData == Keys.Return))
			{
				this.PerformClick();
				kevent.Handled = true;
			}
			base.OnKeyDown(kevent);
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.Invalidate();
			base.OnGotFocus(e);
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.MouseState = MouseState.const_2;
			base.Invalidate();
			base.OnLostFocus(e);
		}

		private Image method_1()
		{
			if (this.DefaultHoveredState.Image != null)
			{
				return this.DefaultHoveredState.Image;
			}
			return this.image_0;
		}

		private Size method_2()
		{
			if (!(this.DefaultHoveredState.ImageSize == default(Size)))
			{
				return this.DefaultHoveredState.ImageSize;
			}
			return this.size_0;
		}

		private Point method_3()
		{
			if (!(this.DefaultHoveredState.ImageOffset == default(Point)))
			{
				return this.DefaultHoveredState.ImageOffset;
			}
			return this.point_0;
		}

		private Image method_4()
		{
			if (this.DefaultPressedState.Image != null)
			{
				return this.DefaultPressedState.Image;
			}
			return this.method_1();
		}

		private Size method_5()
		{
			if (!(this.DefaultPressedState.ImageSize == default(Size)))
			{
				return this.DefaultPressedState.ImageSize;
			}
			return this.method_2();
		}

		private Point method_6()
		{
			if (!(this.DefaultPressedState.ImageOffset == default(Point)))
			{
				return this.DefaultPressedState.ImageOffset;
			}
			return this.method_3();
		}

		private Image method_7()
		{
			if (this.DefaultCheckedState.Image != null)
			{
				return this.DefaultCheckedState.Image;
			}
			return this.method_1();
		}

		private Size method_8()
		{
			if (!(this.DefaultCheckedState.ImageSize == default(Size)))
			{
				return this.DefaultCheckedState.ImageSize;
			}
			return this.method_2();
		}

		private Point method_9()
		{
			if (!(this.DefaultCheckedState.ImageOffset == default(Point)))
			{
				return this.DefaultCheckedState.ImageOffset;
			}
			return this.method_3();
		}

		private void method_10(Graphics graphics_0)
		{
			Image image = this.image_0;
			Size size = this.size_0;
			Point point = this.point_0;
			if (this.bool_4)
			{
				image = this.method_7();
				point = this.method_9();
				size = this.method_8();
			}
			else
			{
				switch (base.MouseState)
				{
				case MouseState.DOWN:
					image = this.method_4();
					point = this.method_6();
					size = this.method_5();
					break;
				case MouseState.HOVER:
					image = this.method_1();
					point = this.method_3();
					size = this.method_2();
					break;
				}
			}
			if (image != null)
			{
				Rectangle rect = new Rectangle(point.X, point.Y, size.Width, size.Height);
				rect.X += Class6.smethod_8(size.Width, base.Width);
				rect.Y += Class6.smethod_8(size.Height, base.Height);
				graphics_0.DrawImage(image, rect);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (!base.Enabled)
			{
				Bitmap image = new Bitmap(base.Width, base.Height);
				this.method_10(Graphics.FromImage(image));
				ControlPaint.DrawImageDisabled(e.Graphics, image, 0, 0, Color.White);
			}
			else
			{
				this.method_10(e.Graphics);
			}
			base.OnPaint(e);
		}
	}
}
