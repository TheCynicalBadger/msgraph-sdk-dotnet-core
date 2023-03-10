﻿// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Microsoft.Graph.DotnetCore.Core.Test.TestModels.ServiceModels
{
    public class TestEventsDeltaResponse : IParsable,IAdditionalDataHolder
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        
        public string OdataDeltaLink { get; set; }
        
        public string OdataNextLink { get; set; }

        public List<TestEventItem> Value { get; set; }
        /// <summary>
        /// Instantiates a new eventsResponse and sets the default values.
        /// </summary>
        public TestEventsDeltaResponse()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>> {
                {"@odata.deltaLink", n => { OdataDeltaLink = n.GetStringValue(); } },
                {"@odata.nextLink", n => { OdataNextLink = n.GetStringValue(); } },
                {"value", (n) => { Value = n.GetCollectionOfObjectValues<TestEventItem>(TestEventItem.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("@odata.deltaLink", OdataDeltaLink);
            writer.WriteStringValue("@odata.nextLink", OdataNextLink);
            writer.WriteCollectionOfObjectValues<TestEventItem>("value", Value);
            writer.WriteAdditionalData(AdditionalData);
        }

        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static TestEventsDeltaResponse CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new TestEventsDeltaResponse();
        }
    }
}
