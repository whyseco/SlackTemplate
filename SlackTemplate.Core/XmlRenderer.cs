using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace SlackTemplate.Core
{
	public class DefaultXmlRenderer : XmlRenderer
	{
		public DefaultXmlRenderer()
		{
			this.InlineRenderers = new Dictionary<string, IInlineRenderer>()
			{
				{  "b", new StrongRenderer() },
				{  "strong", new StrongRenderer() }
			};
		}
	}

	public class XmlRenderer
	{
		public IDictionary<string, IElementRenderer> ElementRenderers { get; set; }
		public IDictionary<string, IInlineRenderer> InlineRenderers { get; set; }

		public void Render(XDocument document, object root)
		{
			foreach (var element in document.Elements())
			{
				this.Render(element, root);
			}
		}

		private string RenderInline(XElement element)
		{
			var hasRenderer = this.InlineRenderers.TryGetValue(element.Name.LocalName, out var renderer);

			if (!hasRenderer)
				throw new ArgumentException($"Cannot render inline node type : {element.Name.LocalName}");

			return renderer.Render(element);
		}

		public void Render(XElement element, object root)
		{
			var hasTransformer = this.ElementRenderers.TryGetValue(element.Name.LocalName, out var transformer);

			if (!hasTransformer)
				throw new ArgumentException($"Cannot transform node type : {element.Name.LocalName}");

			string inlineContent = null;
			foreach (var node in element.Nodes())
			{
				if (node.NodeType == System.Xml.XmlNodeType.Text)
				{
					inlineContent += node.ToString();
				}
				else if (node is XElement xe)
				{
					inlineContent += this.RenderInline(xe);
				}
			}

			element.Value = inlineContent;
			var result = transformer.Render(element, root);

			foreach (var child in element.Elements())
			{
				this.Render(child, result);
			}
		}
	}
}
