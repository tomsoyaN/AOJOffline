using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Rendering;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace AOJ_App.Editor
{
    class HighLightRenderer : IBackgroundRenderer
    {
        public Block2 curblock;
        private List<TextSegment> segments = new List<TextSegment>{new TextSegment(),new TextSegment()};
        public HighLightRenderer()
        {
        }
        public KnownLayer Layer
        {
            get { return KnownLayer.Selection; }
        }

        public void Draw(TextView textView, DrawingContext drawingContext)
        {
            if (curblock.parent == null || curblock.state == Block2.DEACTIVE) return;
            segments[0].StartOffset = curblock.startpos;
            segments[0].StartOffset = curblock.startpos;
            segments[1].StartOffset = curblock.endpos;
            segments[1].StartOffset = curblock.endpos;
            foreach (var seg in segments)
            {
                foreach (var rect in BackgroundGeometryBuilder.GetRectsForSegment(textView, seg))
                {
                    drawingContext.DrawRectangle(Brushes.Gray, null, new Rect(rect.Location, new Size(rect.Width, rect.Height)));
                }
            }
        }
        
    }
}
