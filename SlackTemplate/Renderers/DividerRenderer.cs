using SlackLibrary.Models.Blocks;
using SlackTemplate.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace SlackTemplate.Renderers
{
	public class DividerRenderer : ElementRenderer<RootBlock>
	{
		public const string Name = "divider";

		public override object Render(XElement element, RootBlock root)
		{
			var sectionBlock = new DividerBlock();
			root.Layouts.Add(sectionBlock);

			return sectionBlock;
		}
	}
}
