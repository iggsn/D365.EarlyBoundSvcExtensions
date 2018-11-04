using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace D365.EarlyBoundSvcExtensions.Core
{
    public static class Serializer
    {
        /// <summary>
        /// Deserializes the specified serialized object, using an DataContractSerializer.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="serializedObject">The serialized object.</param>
        /// <returns></returns>
        public static T DeserializeJsonDc<T>(MemoryStream serializedObject)
        {
            serializedObject.Position = 0;
            var serializer = new DataContractJsonSerializer(typeof(T),
                new DataContractJsonSerializerSettings
                {
                    DateTimeFormat = new DateTimeFormat("yyyy-MM-dd hh:mm:ss")
                });
            return (T)serializer.ReadObject(serializedObject);
        }

        /// <summary>
        /// Serializes the specified value, using an DataContractSerializer.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        public static string SerializeJsonDc<T>(T value, Encoding encoding = null)
        {
            string result = string.Empty;
            try
            {
                MemoryStream stream = new MemoryStream();

                var serializer = new DataContractJsonSerializer(typeof(T),
                    new DataContractJsonSerializerSettings
                    {
                        DateTimeFormat = new DateTimeFormat("yyyy-MM-dd hh:mm:ss"),
                        EmitTypeInformation = EmitTypeInformation.AsNeeded,
                    });

                serializer.WriteObject(stream, value);

                byte[] json = stream.ToArray();
                stream.Close();

                result = Encoding.UTF8.GetString(json, 0, json.Length);
            }
            catch (InvalidDataContractException idce)
            {
                //Trace.Default.Error(idce, $"Source:{idce.Source} | {idce.Message}");
            }
            catch (SerializationException se)
            {
                //Trace.Default.Error(se, $"Source:{se.Source} | {se.Message}");
            }
            catch (Exception e)
            {
                //Trace.Default.Error(e, e.InnerException?.Message ?? e.Message);
                throw;
            }

            return result;
        }
    }
}
