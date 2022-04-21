namespace Pizza
{
    internal class PlainPizza : Pizza
    {
        public PlainPizza()
        {
            this.name = "Plain Pizza";
            this.price = 7.25;
        }

        public override void make()
        {
            throw new NotImplementedException();
        }
    }
}
