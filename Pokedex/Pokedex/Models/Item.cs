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

        string [] weaknesses;
        public string [] Weaknesses
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
    }
}
