using SlackTemplate.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlackTemplate
{
	public class SlackLibraryTemplateRenderer : TemplateRenderer<RootBlock>
	{
		public SlackLibraryTemplateRenderer() : base(new SlackLibraryRenderer())
		{
		}
	}
}
