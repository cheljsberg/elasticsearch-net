﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Elasticsearch.Net;
using Newtonsoft.Json;

namespace Nest
{
	public class MultiTermVectorDocument
	{
		[JsonProperty("_index")]
		public IndexName Index { get; set; }
		[JsonProperty("_type")]
		public TypeName Type { get; set; }
		[JsonProperty("_id")]
		public string Id { get; set; }
		[JsonProperty("doc")]
		public object Document { get; set; }
		[JsonProperty("fields")]
		public IEnumerable<FieldName> Fields { get; set; }
		[JsonProperty("offsets")]
		public bool? Offsets { get; set; }
		[JsonProperty("payloads")]
		public bool? Payloads { get; set; }
		[JsonProperty("positions")]
		public bool? Positions { get; set; }
		[JsonProperty("term_statistics")]
		public bool? TermStatistics { get; set; }
		[JsonProperty("field_statistics")]
		public bool? FieldStatistics { get; set; }
	}

	public class MultiTermVectorDocumentDescriptor<T> : RequestDescriptorBase<MultiTermVectorDocumentDescriptor<T>, MultiTermVectorsRequestParameters>, 
		IMultiTermVectorDocumentDescriptor 
		where T : class
	{

		MultiTermVectorDocument IMultiTermVectorDocumentDescriptor.Document { get; set; }

		MultiTermVectorDocument IMultiTermVectorDocumentDescriptor.GetDocument()
		{
			// TODO : Fix this
			//IMultiTermVectorDocumentDescriptor d = this;
			//if (d.Document == null) d.Document = new MultiTermVectorDocument();
			//d.Document.Id = Self.Id;
			//d.Document.Document = d.Document.Document;
			//d.Document.Type = Self.Type;
			//d.Document.Index = Self.Index;
			//return d.Document;
			return null; 
		}

		private MultiTermVectorDocumentDescriptor<T> SetDocValue(Action<IMultiTermVectorDocumentDescriptor> setter)
		{
			IMultiTermVectorDocumentDescriptor d = this;
			if (d.Document == null) d.Document = new MultiTermVectorDocument();
			setter(d);
			return this;
		}

		public MultiTermVectorDocumentDescriptor<T> Document<TDocument>(TDocument document)
			where TDocument : class
		{
			return this.SetDocValue(d => d.Document.Document = document);
		}

		public MultiTermVectorDocumentDescriptor<T> Fields(params string[] fields)
		{
			return this.SetDocValue(d => d.Document.Fields = fields.Select(f => (FieldName)f).ToList());
		} 
		public MultiTermVectorDocumentDescriptor<T> Fields(params Expression<Func<T, object>>[] fields)
		{
			return this.SetDocValue(d => d.Document.Fields = fields.Select(f => (FieldName)f).ToList());
		} 
		public MultiTermVectorDocumentDescriptor<T> Fields(Func<FluentFieldList<T>, FluentFieldList<T>>  fields)
		{
			return this.SetDocValue(d => d.Document.Fields = fields(new FluentFieldList<T>()).ToList());
		}


		public MultiTermVectorDocumentDescriptor<T> Offsets(bool offsets = true)
		{
			return this.SetDocValue(d =>d.Document.Offsets = offsets);
		}
		public MultiTermVectorDocumentDescriptor<T> Payloads(bool payloads = true)
		{
			return this.SetDocValue(d =>d.Document.Payloads = payloads);
		}
		public MultiTermVectorDocumentDescriptor<T> Positions(bool positions = true)
		{
			return this.SetDocValue(d =>d.Document.Positions = positions);
		}
		public MultiTermVectorDocumentDescriptor<T> TermStatistics(bool termStatistics = true)
		{
			return this.SetDocValue(d => d.Document.TermStatistics = termStatistics);
		}
		public MultiTermVectorDocumentDescriptor<T> FieldStatistics (bool fieldStatistics = true)
		{
			return this.SetDocValue(d => d.Document.FieldStatistics = fieldStatistics);
		}
	}
}