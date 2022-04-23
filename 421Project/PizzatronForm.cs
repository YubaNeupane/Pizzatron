using System.Diagnostics;
using MainProgram;
using Toppings;
using Utility;

namespace _421Project
{
    public partial class PizzatronForm : Form
    {
        OrderingMachine orderingMachine;
        

        public PizzatronForm()
        {
            orderingMachine = new OrderingMachine();
            InitializeComponent();

            displayMenu();

        }

        private void displayMenu()
        {
            listPizzaBaseMenu.Items.Clear();
            foreach(PizzaBaseFromFile pizzaItem in orderingMachine.getPizzaBaseFromFile())
            {
                ListViewItem listViewItem = new ListViewItem(pizzaItem.Name);
                listViewItem.SubItems.Add(pizzaItem.price.ToString("C2"));

                listPizzaBaseMenu.Items.Add(listViewItem);
             
            }
        }



        private void updateSelectedPizzaBase()
        {
            PizzaBaseFromFile pizzaBaseFromFile = orderingMachine.getSelctedPizzaBase();
            lblSelectedBasePizza.Text = pizzaBaseFromFile.Name + " \n" + pizzaBaseFromFile.price.ToString("C2");
        }

        private void updateSelectedTopping()
        {

        }

     

        private void listPizzaBaseMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listPizzaBaseMenu.SelectedIndices.Count == 1)
            {
                orderingMachine.setSelectedPizzaBase(listPizzaBaseMenu.SelectedIndices[0]);
                updateSelectedPizzaBase();
            }
        }
    }
}