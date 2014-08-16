using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace IST.OrderSynchronizationSystem.GUI
{
    public class DataGridViewDisableButtonCell : DataGridViewButtonCell
    {
        private bool _enabledValue;
        public bool Enabled
        {
            get
            {
                return _enabledValue;
            }
            set
            {
                _enabledValue = value;
            }
        }

        // Override the Clone method so that the Enabled property is copied. 
        public override object Clone()
        {
            var cell = (DataGridViewDisableButtonCell)base.Clone();
            cell.Enabled = this.Enabled;
            return cell;
        }

        // By default, enable the button cell. 
        public DataGridViewDisableButtonCell()
        {
            this._enabledValue = true;
        }

        protected override void Paint(Graphics graphics,
            Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
            DataGridViewElementStates elementState, object value,
            object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            // The button cell is disabled, so paint the border,   
            // background, and disabled button for the cell. 
            if (!this._enabledValue)
            {
                // Draw the cell background, if specified. 
                if ((paintParts & DataGridViewPaintParts.Background) ==
                    DataGridViewPaintParts.Background)
                {
                    SolidBrush cellBackground =
                        new SolidBrush(cellStyle.BackColor);
                    graphics.FillRectangle(cellBackground, cellBounds);
                    cellBackground.Dispose();
                }

                // Draw the cell borders, if specified. 
                if ((paintParts & DataGridViewPaintParts.Border) ==
                    DataGridViewPaintParts.Border)
                {
                    PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
                        advancedBorderStyle);
                }

                // Calculate the area in which to draw the button.
                var buttonArea = cellBounds;
                var buttonAdjustment =
                    this.BorderWidths(advancedBorderStyle);
                buttonArea.X += buttonAdjustment.X;
                buttonArea.Y += buttonAdjustment.Y;
                buttonArea.Height -= buttonAdjustment.Height;
                buttonArea.Width -= buttonAdjustment.Width;

                // Draw the disabled button.                
                ButtonRenderer.DrawButton(graphics, buttonArea,
                    PushButtonState.Disabled);

                // Draw the disabled button text.  
                if (this.FormattedValue is String)
                {
                    //TextRenderer.DrawText(graphics, (string) this.FormattedValue, this.DataGridView.Font, buttonArea, SystemColors.GrayText);
                    TextRenderer.DrawText(graphics, (string)this.FormattedValue, new System.Drawing.Font("Arial", 8.5F, FontStyle.Strikeout), buttonArea, Color.Crimson);

                }
            }
            else
            {
                // The button cell is enabled, so let the base class  
                // handle the painting. 
                base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                    elementState, value, formattedValue, errorText,
                    cellStyle, advancedBorderStyle, paintParts);
            }
        }
    }
}
