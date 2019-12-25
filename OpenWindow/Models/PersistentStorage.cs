using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace OpenWindow.Models
{
    /// <summary>
    /// Store objects to disk in a binary serialized format
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class PersistentStorage<T>
    {
        /// <summary>
        /// Saves a copy of the provided object to disk with the provided filename.
        /// </summary>
        /// <param name="obj">The object to store</param>
        /// <param name="filename">The filename to store the object as</param>
        public static void Save(T obj, string filename)
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream fs = new FileStream(filename, FileMode.Create);
            bf.Serialize(fs, obj);
            fs.Flush();
            fs.Close();
        }

        /// <summary>
        /// Reads the object with the specified filename.
        /// </summary>
        /// <param name="filename">The filename to read from the disk</param>
        /// <returns></returns>
        public static T Restore(string filename)
        {
            T e = default(T);

            if (!File.Exists(filename))
                return e;

            BinaryFormatter bf = new BinaryFormatter();

            FileStream fs = new FileStream(filename, FileMode.Open);

            try
            {
                e = (T)bf.Deserialize(fs);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            finally
            {
                fs.Close();
            }

            return e;
        }
    }
}
