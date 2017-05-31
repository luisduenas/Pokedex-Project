using System.Collections.Generic;

namespace Pokedex.Models
{
    public class Item : BaseDataObject
	{
		string name = string.Empty;
		public string Name
		{
			get { return name; }
			set { SetProperty(ref name, value); }
		}
		string description = string.Empty;
		public string Description
		{
			get { return description; }
			set { SetProperty(ref description, value); }
		}
        int num = 0;
        public int Num
        {
            get { return num; }
            set { SetProperty(ref num, value); }
        }
        string height = string.Empty;
        public string Height
        {
            get { return height; }
            set { SetProperty(ref height, value); }
        }
        string weight = string.Empty;
        public string Weight
        {
            get { return weight; }
            set { SetProperty(ref weight, value); }
        }
        List<string>  weaknesses;
        public List<string>  Weaknesses
        {
            get { return weaknesses; }
            set { SetProperty(ref weaknesses, value); }
        }
        string type1 = "-----";
        public string Type1
        {
            get { return type1; }
            set { SetProperty(ref type1, value); }
        }
        string type2 = "-----";
        public string Type2
        {
            get { return type2; }
            set { SetProperty(ref type2, value); }
        }
        string source = string.Empty;
        public string Source
        {
            get { return source; }
            set { SetProperty(ref source, value); }
        }
        string evolution1 = string.Empty;
        public string Evolution1
        {
            get { return evolution1; }
            set { SetProperty(ref evolution1, value); }
        }
        string evolution2 = string.Empty;
        public string Evolution2
        {
            get { return evolution2; }
            set { SetProperty(ref evolution2, value); }
        }
        string evolution3 = string.Empty;
        public string Evolution3
        {
            get { return evolution3; }
            set { SetProperty(ref evolution3, value); }
        }
    }
}
