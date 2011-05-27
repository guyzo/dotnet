#region License
// Copyright (c) 2010 Nano Taboada, http://openid.nanotaboada.com.ar
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
#endregion

namespace Dotnet.Samples.Extensions
{
    #region References
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Xml.Serialization;
    #endregion
    
    /// <summary>
    /// Provides generic extension methods for serialization into XML, JSON and SOAP.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Serializes the contents of a System.Object to XML using this System.IO.Stream.
        /// </summary>
        /// <typeparam name="T">The type of the System.Object.</typeparam>
        /// <param name="target">The System.IO.Stream used to write the XML data.</param>
        /// <param name="source">The System.Object to serialize.</param>
        public static void SerializeToXml<T>(this Stream target, T source)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            xmlSerializer.Serialize(target, source);
        }

        /// <summary>
        /// Deserializes the XML data contained on this System.IO.Stream to a System.Object.
        /// </summary>
        /// <typeparam name="T">The type of the System.Object.</typeparam>
        /// <param name="source">The System.IO.Stream that contains the XML data to deserialize.</param>
        public static T DeserializeFromXml<T>(this Stream source)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            return (T)xmlSerializer.Deserialize(source);
        }

        /// <summary>
        /// Serializes the contents of a System.Object to JSON using this System.IO.Stream.
        /// </summary>
        /// <typeparam name="T">The type of the System.Object.</typeparam>
        /// <param name="target">The System.IO.Stream used to write the JSON data.</param>
        /// <param name="source">The System.Object to serialize.</param>
        public static void SerializeToJson<T>(this Stream target, T source)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
            jsonSerializer.WriteObject(target, source);
        }

        /// <summary>
        /// Deserializes the JSON data contained on this System.IO.Stream to a System.Object.
        /// </summary>
        /// /// <typeparam name="T">The type of the System.Object.</typeparam>
        /// <param name="source">The System.IO.Stream that contains the JSON data to deserialize.</param>
        public static T DeserializeFromJson<T>(this Stream source)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
            return (T)jsonSerializer.ReadObject(source);
        }

        // TODO: Implement extension method for generic SOAP serialization.
    }
}
