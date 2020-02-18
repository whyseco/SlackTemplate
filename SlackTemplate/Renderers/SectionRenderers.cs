using SlackLibrary.Models.Blocks;
using SlackLibrary.Models.Blocks.Objects;
using SlackTemplate.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace SlackTemplate.Renderers
{
	public class SectionRenderer : ElementRenderer<RootBlock>
	{
		public const string Name = "section";

		public override object Render(XElement element, RootBlock root)
		{
			var sectionBlock = new SectionBlock() { Text = new TextObject(element.Value) };
			root.Layouts.Add(sectionBlock);

			return sectionBlock;
		}
	}
}
