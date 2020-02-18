using SlackLibrary.Models.Blocks.Objects;
using SlackTemplate.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace SlackTemplate.Renderers
{
	public class ImageRenderer : ImageBlockRenderer<RootBlock>
	{
		public const string Name = "image";

		public override object Render(XElement element, RootBlock root)
		{
			var block = this.ParseElement(element);
			var sectionBlock = new SlackLibrary.Models.Blocks.ImageBlock(block.ImageUrl, block.AltText) 
			{ 
				Title = new TextObject(block.Title, TextObjectType.PlainText), 
				BlockId = block.BlockId 
			};
			root.Layouts.Add(sectionBlock);

			return sectionBlock;
		}
	}
}
