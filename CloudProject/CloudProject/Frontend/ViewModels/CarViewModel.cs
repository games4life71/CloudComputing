namespace Frontend.ViewModels;

public class CarViewModel
{

        public string id { get; set; }
        public string name { get; set; }
        public object speed { get; set; }
        public int year { get; set; }


        public CarViewModel(string id, string name, object speed, int year)
        {
                this.id = id;
                this.name = name;
                this.speed = speed;
                this.year = year;
        }

}