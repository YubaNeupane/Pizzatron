<!DOCTYPE html>
<html>
  <head>
    <meta charset="UTF-8">
  </head>
  <body>
    <h1>Pizzatron</h1>
    <p>Pizzatron is a pizza-making application that allows users to create their own pizzas using a graphical user interface (GUI) and watch the progress of the pizza being made. This project showcases the use of various design patterns, including the Factory, Builder, and Observer patterns.</p>
    

    
    <h2>Installation</h2>
    <ol>
      <li>Clone the repository to your local machine using Git.</li>
      <li>Open the solution file (`Pizzatron.sln`) in Visual Studio.</li>
      <li>Build the solution by selecting <strong>Build Solution</strong> from the <strong>Build</strong> menu.</li>
      <li>Run the application by pressing <strong>F5</strong> or selecting <strong>Debug &gt; Start Debugging</strong> from the menu.</li>
    </ol>
    
    <h2>Usage</h2>
    <p>When you run the application, you will see the main window with various pizza ingredients on the left and a pizza canvas on the right. To create a pizza, simply drag and drop the desired ingredients onto the pizza canvas. You can also remove ingredients by right-clicking on them.</p>
    <p>Once you have finished creating your pizza, click the <strong>Order</strong> button to submit your order. You will then see a progress bar showing the progress of your pizza being made. You can cancel your order at any time by clicking the <strong>Cancel</strong> button.</p>
    
    <h2>Design Patterns Used</h2>
    <h3>Factory Pattern</h3>
    <p>The Factory pattern is used to create the pizza ingredients. There is a base <code>Ingredient</code> class, and then specific ingredient classes derived from it (e.g. <code>Cheese</code>, <code>Pepperoni</code>, <code>Mushrooms</code>). The <code>IngredientFactory</code> class is responsible for creating instances of these classes based on user input.</p>
    
    <h3>Builder Pattern</h3>
    <p>The Builder pattern is used to create the pizza itself. The <code>PizzaBuilder</code> class is responsible for creating instances of <code>Pizza</code> based on the ingredients added by the user. The <code>Pizza</code> class has various properties (e.g. <code>Crust</code>, <code>Toppings</code>) that are set by the <code>PizzaBuilder</code> based on user input.</p>
    
    <h3>Observer Pattern</h3>
    <p>The Observer pattern is used to update the progress bar when the pizza is being made. The <code>Pizza</code> class is the subject, and the <code>ProgressBar</code> is the observer. When the <code>Pizza</code> class updates its state (e.g. from "preparing" to "baking"), it notifies the <code>ProgressBar</code>, which updates its value accordingly.</p>
    
    <h3>Abstract Factory Pattern</h3>
<p>The Abstract Factory pattern is used to create different types of pizzas. There is a base <code>Pizza</code> class, and then specific pizza classes derived from it (e.g. <code>CheesePizza</code>, <code>PepperoniPizza</code>, <code>VegetarianPizza</code>). The <code>PizzaFactory</code> class is responsible for creating instances of these classes based on user input.</p>

<h3>Strategy Pattern</h3>
<p>The Strategy pattern is used to change the behavior of the <code>PizzaBuilder</code> class based on user input. For example, the user can choose between a thin crust and a thick crust, which changes how the <code>PizzaBuilder</code> builds the pizza.</p>

<h2>Contributing</h2>
<p>If you would like to contribute to Pizzatron, please follow these steps:</p>
<ol>
  <li>Fork the repository.</li>
  <li>Create a new branch for your changes.</li>
  <li>Make your changes and commit them with a descriptive message.</li>
  <li>Push your changes to your forked repository.</li>
  <li>Create a pull request.</li>
</ol>

 </body>
</html>
