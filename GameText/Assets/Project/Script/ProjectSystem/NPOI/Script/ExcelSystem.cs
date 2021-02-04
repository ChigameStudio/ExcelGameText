using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//共通 NPOI
using NPOI;
using NPOI.SS.UserModel;
//標準xlsバージョン
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
//拡張xlsxバージョン
using NPOI.XSSF;
using NPOI.XSSF.UserModel;

using System.Globalization;
using System;

namespace ProjectSystem
{
    /// <summary>
    /// Excelのシステム
    /// </summary>
    public static class ExcelSystem
    {
        /// <summary>
        /// データクラス
        /// </summary>
        public class Data
        {
            private string data_name_ = "";
            public string GetDataName
            {
                get { return data_name_; }
            }
            private string data_object_ = null;
            public string GetDataObject
            {
                get { return data_object_; }
            }


            /// <summary>
            /// セットアップ
            /// </summary>
            /// <param name="data_name"></param>
            /// <param name="data_object"></param>
            public void SetUp(string data_name,string data_object)
            {
                data_name_ = data_name;
                data_object_ = data_object;
            }


        }

        /// <summary>
        /// データグループ
        /// </summary>
        public class DataGroup
        {
            private uint group_id_ = 1;
            public uint GetGroupID
            {
                get { return group_id_; }
            }
            private List<Data> list_data_group_ = new List<Data>();
            public void SetUp(uint value_id)
            {
                group_id_ = value_id;
                list_data_group_ = new List<Data>();
            }
            public void SetAdd(string data_name,string data_object)
            {
                if (list_data_group_ == null) return;
                Data data = new Data();
                data.SetUp(data_name, data_object);
                list_data_group_.Add(data);
            }
            public Data GetData(string serach_data_name)
            {
                if (list_data_group_ == null) return null;
                if (list_data_group_.Count == 0) return null;

                return list_data_group_.Find(data => data.GetDataName == serach_data_name);
            }
            public Data GetData(uint serach_data_index)
            {
                if (list_data_group_ == null) return null;
                if (list_data_group_.Count == 0) return null;
                if (serach_data_index >= list_data_group_.Count) return null;

                return list_data_group_[(int)serach_data_index];
            }
        }

        public class DataControl
        {
            private List<DataGroup> list_data_group_ = new List<DataGroup>();
            List<string> list_data_name_ = new List<string>();
            public void SetUp(List<string> value_list_data_name)
            {
                list_data_group_ = new List<DataGroup>();
                list_data_name_ = value_list_data_name;
            }


            public DataGroup AddGroup(DataGroup data_group)
            {
                if (data_group == null) return null;
                list_data_group_.Add(data_group);

                return data_group;
            }
            public DataGroup GetDataGroupID(uint search_data_group_id)
            {
                if (list_data_group_ == null) return null;
                if (list_data_group_.Count == 0) return null;

                return list_data_group_.Find(data => data.GetGroupID == search_data_group_id);
            }
            public DataGroup GetDataGroupIndex(uint search_data_group_index)
            {
                if (list_data_group_ == null) return null;
                if (list_data_group_.Count == 0) return null;
                if (search_data_group_index >= list_data_group_.Count) return null;
                return list_data_group_[(int)search_data_group_index];
            }
            public Data GetDataName(uint search_data_group_id,string search_data_name)
            {
                if (list_data_name_ == null) return null;
                if (list_data_name_.Count == 0) return null;
                if (string.IsNullOrWhiteSpace(search_data_name)) return null;

                DataGroup data_group = GetDataGroupID(search_data_group_id);
                if (data_group == null) return null;
                return data_group.GetData(search_data_name);
               
            }

            public Data GetDataName(uint search_data_group_id, uint search_data_index)
            {
                if (list_data_name_ == null) return null;
                if (list_data_name_.Count == 0) return null;

                DataGroup data_group = GetDataGroupID(search_data_group_id);
                if (data_group == null) return null;
                return data_group.GetData(search_data_index);

            }
            public Data GetDataNameIndex(uint search_data_group_index, string search_data_name)
            {
                if (list_data_name_ == null) return null;
                if (list_data_name_.Count == 0) return null;
                if (string.IsNullOrWhiteSpace(search_data_name)) return null;

                DataGroup data_group = GetDataGroupIndex(search_data_group_index);
                if (data_group == null) return null;
                return data_group.GetData(search_data_name);
            }
            public Data GetDataNameIndex(uint search_data_group_index, uint search_data_index)
            {
                if (list_data_name_ == null) return null;
                if (list_data_name_.Count == 0) return null;
                if (search_data_index >= list_data_name_.Count) return null;

                DataGroup data_group = GetDataGroupIndex(search_data_group_index);
                if (data_group == null) return null;
                return data_group.GetData(search_data_index);
            }


            public string GetDataListNameIndex(uint search_list_data_name_index)
            {
                if (list_data_name_ == null) return null;
                if (list_data_name_.Count >= search_list_data_name_index) return null;

                return list_data_name_[(int)search_list_data_name_index];
            }

            public void CovertDataList(ref int out_object,int search_list_data_group_index,string search_data_name)
            {
                var data = GetDataNameIndex((uint)search_list_data_group_index,search_data_name);
                if (data == null) return;

                string data_object = data.GetDataObject;

                if(out_object.GetType() == typeof(int))
                {
                    out_object = int.Parse(data_object);
                }

            }

            public void CovertDataList(ref float out_object, int search_list_data_group_index, string search_data_name)
            {
                var data = GetDataNameIndex((uint)search_list_data_group_index, search_data_name);
                if (data == null) return;

                string data_object = data.GetDataObject;

                if (out_object.GetType() == typeof(int))
                {
                    out_object = float.Parse(data_object);
                }

            }

            public void CovertDataList(ref string out_object, int search_list_data_group_index, string search_data_name)
            {
                var data = GetDataNameIndex((uint)search_list_data_group_index, search_data_name);
                if (data == null) return;

                string data_object = data.GetDataObject;

                out_object = data_object;

            }

            public bool CovertDataList(ref bool out_object, int search_list_data_group_index, string search_data_name)
            {
                var data = GetDataNameIndex((uint)search_list_data_group_index, search_data_name);
                if (data == null) return false;

                string data_object = data.GetDataObject;

                string[] true_name = new string[]
                {
                    "TRUE","True","true"
                };
                string[] false_name = new string[]
                {
                    "FALSE","False","false"
                };

                foreach(var name in true_name)
                {
                    if (name == data_object)
                    {
                        out_object = true;
                        return true;
                    }
                }
                foreach (var name in false_name)
                {
                    if (name == data_object)
                    {
                        out_object = false;
                        return true;
                    }
                }

                return false;



            }

        }

        /// <summary>
        /// エラーカウント(最大)
        /// </summary>
        private  const uint max_error_row_count = 10;
        private const uint max_error_cell_count = 10;

        public static DataControl GetExcelLoadData(string load_excel_path,string load_sheet_name)
        {
            var sheet = ExcelLoadSheet(ExceLoadBook(load_excel_path), load_sheet_name);
            if (sheet == null) return null;

            return CreateData(sheet);
        }

        private static DataControl CreateData(ISheet sheet)
        {
            if (sheet == null) return null;

            var check_data = VoidCheckSheet(sheet);
            if (check_data.Item1 == null) return null;
            if (check_data.Item1.Count == 0) return null;

            return SetUpDataControl(sheet, check_data.Item2, check_data.Item3, check_data.Item1);

        }

        private static DataControl SetUpDataControl(ISheet sheet,uint rou_num,uint cell_num,List<string> value_list_data_name)
        {
            DataControl data_control = new DataControl();
            data_control.SetUp(value_list_data_name);

            int start_count_row = (int)rou_num;
            int start_count_cell = (int)cell_num;

            int start_count_loop_row = start_count_row;
            int start_count_loop_cell = start_count_cell;

            bool is_loop = true;
            bool is_end = false;
            bool is_loop_data_create = true;

            uint id_count = 0;

            while(is_loop == true)
            {
                var cell = ExcelLoadCell(sheet, start_count_loop_row, start_count_loop_cell);
                start_count_loop_cell++;
                if (is_end)
                {
                    if (VoidCheck(cell))
                    {
                        is_loop = false;
                        return data_control;
                    }
                    else
                    {
                        is_end = false;
                    }
                }
                else
                {
                    if (VoidCheck(cell))
                    {
                        start_count_loop_cell = start_count_cell;
                        start_count_loop_row++;
                        is_end = true;
                        continue;
                    }
                    else
                    {
                        is_loop_data_create = true;
                        while (is_loop_data_create == true)
                        {
                            uint cout = 0;
                            DataGroup data_group = new DataGroup();
                            data_group.SetUp(id_count);
                            foreach(var name in value_list_data_name)
                            {
                                string add_data = GetData(cell);
                                data_group.SetAdd(name, add_data);
                                cout++;
                                cell = ExcelLoadCell(sheet, start_count_loop_row, (start_count_loop_cell - 1) + (int)cout);
                            }
                            data_control.AddGroup(data_group);
                            start_count_loop_cell = start_count_cell;
                            start_count_loop_row++;
                            id_count++;
                            is_loop_data_create = false;
                            break;
                        }
                    }

                }

            }

            return data_control;


        }

        private static string GetData(ICell cell)
        {
            if (cell == null) return "";

            string check_name = "";
            if (cell.CellType == CellType.Numeric)
            {
                check_name = cell.NumericCellValue.ToString();
            }
            else
            {
                check_name = cell.StringCellValue;
            }
            return check_name;
        }

        private static (List<string>,uint,uint) VoidCheckSheet(ISheet sheet)
        {
            ///行
            int start_row_count = 0;
            ///列
            int start_cell_count = 0;

            ///Loopフラグ
            bool is_loop = true;
            ///Loopフラグ
            bool is_loop_data = true;

            uint error_row_count = 0;
            List<string> list_data_name_ = new List<string>();

            while (is_loop == true)
            {
                var cell = ExcelLoadCell(sheet, start_row_count, start_cell_count);
                if (VoidCheck(cell) == true)
                {
                    start_cell_count++;
                    if (start_cell_count >= max_error_cell_count)
                    {
                        if (error_row_count >= max_error_row_count)
                        {
                            return (null, 0, 0);
                        }
                        else
                        {
                            start_row_count++;
                            error_row_count++;
                            start_cell_count = 0;
                        }
                    }
                    continue;
                }
                else
                {
                    is_loop = false;

                    int start_cell_count_loop = start_cell_count;
                    while(is_loop_data == true)
                    {
                        string add_data = GetData(cell);
                        list_data_name_.Add(add_data);
                        start_cell_count_loop++;
                        cell = ExcelLoadCell(sheet, start_row_count, start_cell_count_loop);
                        if(VoidCheck(cell) == true)
                        {
                            is_loop_data = false;
                            return (list_data_name_,(uint)start_row_count + 1,(uint)start_cell_count);
                        }
                    }
                }
            }
            return (null,0,0);
        }

        /// <summary>
        /// ブック読み込み
        /// </summary>
        /// <param name="load_excel_path"></param>
        private static IWorkbook ExceLoadBook(string load_excel_path)
        {
            //エクセル読み込み
            return WorkbookFactory.Create(load_excel_path);
        }

        /// <summary>
        /// シート読み込み
        /// </summary>
        /// <param name="work_book"></param>
        /// <param name="load_sheet_name"></param>
        private static ISheet ExcelLoadSheet(IWorkbook work_book,string load_sheet_name)
        {
            if (work_book == null) return null;
            return work_book.GetSheet(load_sheet_name);
        }

        /// <summary>
        /// 空かどうか
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static bool VoidCheck(ICell cell)
        {
            if (cell == null) return true;

            string check_name = "";
            if(cell.CellType == CellType.Numeric)
            {
                check_name = cell.NumericCellValue.ToString();
            }
            else
            {
                check_name = cell.StringCellValue;
            }
            return string.IsNullOrWhiteSpace(check_name);

        }

        /// <summary>
        /// セル取得
        /// </summary>
        /// <param name="work_sheet"></param>
        /// <param name="row">行</param>
        /// <param name="cell">列</param>
        /// <returns></returns>
        private static ICell ExcelLoadCell(ISheet work_sheet, int row,int cell)
        {
            if (work_sheet == null) return null;
            var get_row = GetRow(work_sheet, row);
            if (get_row == null) return null;
            return GetCell(get_row, cell);
        }

        /// <summary>
        /// シートから行を取得
        /// </summary>
        /// <param name="work_sheet"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private static IRow GetRow(ISheet work_sheet, int row)
        {
            if (work_sheet == null) return null;
            // シートから行を取得
            var get_row = work_sheet.GetRow(row);
            // 行がnullなら
            if (get_row == null) return null;
            // 行をリターン
            return get_row;
        }
        /// <summary>
        /// 行から列を取得
        /// </summary>
        /// <param name="row"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static ICell GetCell(IRow row, int cell)
        {
            if (row == null) return null;
            // 行から列を取得
            var get_cell = row.GetCell(cell);
            // 列がnullなら
            if (get_cell == null) return null;
            // 列をリターン
            return get_cell;
        }
    }
}