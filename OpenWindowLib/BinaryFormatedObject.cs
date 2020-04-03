using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace OpenWindowLib
{
    public class BinaryFormatedObject<T>
    {
        /// <summary>
        /// Saves a copy of the provided object to disk with the provided filename.
        /// </summary>
        /// <param name="obj">The object to store</param>
        /// <param name="filename">The filename to store the object as</param>
        public static void Save(T obj, string filename)
        {
            if(obj == null)
                throw new ArgumentNullException("obj cannot be null");
            if(string.IsNullOrEmpty(filename))
                throw new ArgumentException("filename must contain a value")
        
            BinaryFormatter bf = new BinaryFormatter();
            
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Create);
                bf.Serialize(fs, obj);
            }
            catch(Exception ex)
            {
                // Log Exception
            }
            finally
            (
                fs.Flush();
                fs.Close();
            }
        }

        /// <summary>
        /// Reads the object with the specified filename.
        /// </summary>
        /// <param name="filename">The filename to read from the disk</param>
        /// <returns></returns>
        public static T Restore(string filename)
        {
            T e = default(T);

            if (string.IsNullOrEmpty(filename) || !File.Exists(filename))
            {
                // Log error and return default object
                return e;
            }

            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                FileStream fs = new FileStream(filename, FileMode.Open);
                e = (T)bf.Deserialize(fs);
            }
            catch (Exception exception)
            {
                // Log exception
            }
            finally
            {
                fs.Close();
            }

            return e;
        }
    }
}
