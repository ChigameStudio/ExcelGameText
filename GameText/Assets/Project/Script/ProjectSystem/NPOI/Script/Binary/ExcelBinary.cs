using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ProjectSystem
{
    /// <summary>
    /// ExcelのBinary変換やセーブ、ロード
    /// </summary>
    public class ExcelBinarySystem<T> where T : BaseComposition, new()
    {
        public class ExcelFileBinary
        {
            private FileStream file_stream_;
            private BinaryWriter binary_writer_;
            private BinaryReader binary_reader_;
            public void SetUp(string save_path, string save_name,FileMode file_mode)
            { 
                file_stream_ = new FileStream(save_path + "/" + save_name + ".bin", file_mode);
                if(file_mode == FileMode.Create)binary_writer_ = new BinaryWriter(file_stream_);
                else if (file_mode == FileMode.Open) binary_reader_ = new BinaryReader(file_stream_);
            }

            public void SaveList(List<T> composition)
            {
                binary_writer_.Write(composition.Count);
                foreach(var data in composition)
                {
                    SaveData(data);
                }
            }

            public List<T> LoadList()
            {
                List<T> return_list_data = new List<T>();

                int max_data = binary_reader_.ReadInt32();
                for(int count = 0; count < max_data; count++)
                {
                    T load_data = LoadData();
                    return_list_data.Add(load_data);
                }
                return return_list_data;
            }

            private T LoadData()
            {
                T data = new T();

                foreach (var value_data in data.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance))
                {
                    var save_data = value_data.GetValue(data);
                    object add_data = null;
                    if (save_data.GetType().IsEnum == true)
                    {
                        add_data = binary_reader_.ReadInt32();
                    }
                    else
                    {
                        if (save_data.GetType() == typeof(string))
                        {
                            int get_text_length = binary_reader_.ReadInt32();
                            byte[] byte_text = binary_reader_.ReadBytes(get_text_length);
                            add_data = System.Text.Encoding.UTF8.GetString(byte_text);
                        }
                        else if (save_data.GetType() == typeof(int))
                        {
                            add_data = binary_reader_.ReadInt32();
                        }
                        else if (save_data.GetType() == typeof(bool))
                        {
                            add_data = binary_reader_.ReadBoolean();
                        }
                    }

                    data.SetValue(value_data.Name, add_data);
                }

                return data;
            }

            private void SaveData(T data)
            {
                foreach (var value_data in data.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance))
                {
                    var save_data = value_data.GetValue(data);
                    if (save_data.GetType().IsEnum == true)
                    {
                        binary_writer_.Write((int)save_data);
                    }
                    else
                    {
                        if (save_data.GetType() == typeof(string))
                        {
                            byte[] text_byte = System.Text.Encoding.UTF8.GetBytes(save_data.ToString());
                            int length = text_byte.Length;

                            binary_writer_.Write(length);
                            binary_writer_.Write(text_byte);
                        }
                        else if (save_data.GetType() == typeof(int))
                        {
                            binary_writer_.Write((int)save_data);
                        }

                        else if (save_data.GetType() == typeof(bool))
                        {
                            binary_writer_.Write((bool)save_data);
                        }
                    }
                }
            }



            public void Close()
            {
                if (binary_writer_ != null) binary_writer_.Close();
                if (binary_reader_ != null) binary_reader_.Close();
                if (file_stream_ != null) file_stream_.Close(); ;

            }
        }

        /// <summary>
        /// セーブ
        /// </summary>
        /// <param name="composition"></param>
        /// <param name="save_path"></param>
        /// <param name="save_name"></param>
        public static void SaveBinary(List<T> composition, string save_path, string save_name)
        {
            ExcelFileBinary excel_binary = new ExcelFileBinary();
            excel_binary.SetUp(save_path, save_name,FileMode.Create);

            excel_binary.SaveList(composition);

            excel_binary.Close();


        }

        /// <summary>
        /// ロード
        /// </summary>
        /// <param name="composition"></param>
        /// <param name="save_path"></param>
        /// <param name="save_name"></param>
        public static List<T>  LoadBinary(string save_path, string save_name)
        {
            ExcelFileBinary excel_binary = new ExcelFileBinary();
            excel_binary.SetUp(save_path, save_name, FileMode.Open);

            List<T> return_data =  excel_binary.LoadList();

            excel_binary.Close();

            return return_data;


        }
    }
}
