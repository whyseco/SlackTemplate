using SlackTemplate.Core;
using SlackTemplate.Renderers;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SlackTemplate
{
	public class SlackLibraryRenderer : DefaultXmlRenderer
	{
		public SlackLibraryRenderer()
		{
			this.ElementRenderers = new Dictionary<string, IElementRenderer>()
			{
				{  SectionRenderer.Name, new SectionRenderer() },
				{  DividerRenderer.Name, new DividerRenderer() },
				{  ImageRenderer.Name, new ImageRenderer() },
				{  "img", new ImageRenderer() }
			};
		}

		public RootBlock Render(string xml)
		{
			var root = new RootBlock();

			this.Render(XDocument.Parse(xml), root);

			return root;
		}
	}
}
