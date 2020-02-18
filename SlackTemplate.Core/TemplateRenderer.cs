using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace SlackTemplate.Core
{
	public class TemplateRenderer<T> where T : class, new()
	{
		private readonly XmlRenderer xmlRenderer;

		public TemplateRenderer(XmlRenderer xmlRenderer)
		{
			this.xmlRenderer = xmlRenderer;
		}

		public T Render(string content, object model)
		{
			var tmpl = Scriban.Template.Parse(content);

			return this.Render(tmpl, model);
		}

		public T RenderFile(string filePath, object model)
		{
			var tmpl = Scriban.Template.Parse(File.ReadAllText(filePath), filePath);

			return this.Render(tmpl, model);
		}

		protected T Render(Scriban.Template template, object model)
		{

			var result = template.Render(new { Name = "Yann" });

			var root = new T();
			xmlRenderer.Render(XDocument.Parse(result), root);

			return root;
		}
	}
}
