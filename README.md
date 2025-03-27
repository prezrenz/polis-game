# Lab Exercise 2 - Polis Game and Citizen Class Inheritance and Encapsulation Showcase

## Inheritance and Encapsulation Explanation

The citizen class has the following fields and setters and getters:
- private String name;
    - public String getName();
    - public void generateName();
    - Either a name is passed during instantiation or it is generated.
- private String role;
    - public String getRole();
    - The role cannot be changed after instantiation.
- private String actionText;
    - public String getAction();
    - The action text cannot be changed after instantiation.
- private bool tired;
    - public bool isTired();
    - public void setTired(bool b);
- private int skill;
    - public int getSkill();
    - public void generateSkill();
    - Citizen skill level can only be generated by the generateSkill() method.
- public City city;
    - Acts like a singleton to give the Citizen class access to other parts of the game such as buildings.
- public Random randomGenerator;
    - A random generator for the whole Citizen class and its derived classes.

The public method processCommand() is meant to be overriden by the derived classes.

The Citizen class ensures encapsulates its fields by setting them to private, and its values can only be changed using the setters and can only be retrieved using the getters. If a field does not have a setter, then the programmer can be assured that that field will never be changed outside of that class. Setters and Getters allow for more controlled access to the private fields of the class, encapsulating the complexity and hiding it behind an easier to understand interface.

The Citizen class has the following derived classes, showcasing inheritance:
- SpartanSoldier
    - The SpartanSoldier class overrides the processCommand() to do combat.
    - The SpartanSoldier class has the new private fields int combatSkill and opponent. The constructors are changed to accomodate this.
    - TThe SpartanSoldier class has the new gloat(String gloatTo) and admitDefeat(String admitTo) public methods, which is used by the processCommand() public method.
- Leader
    - The Leader class overrides the processCommand() method and has the new private dismiss() and hire() methods.
- Commander
    - The Commander class has the new private int charisma and draftCost fields.
    - It also has the new generateCharisma() method for the charisma field.
    - The class also overrides the public processCommand() method.
    - The new draft() and training() private methods are also added and are used by processCommand()
- Farmer
    - The Farmer class overrides the processCommand() method. No new fields or methods are added.
- Developer
    - The Developer class overrides the processCommand() method. No new fields or methods are added.
- Merchant
    - The Merchant class overrides the processCommand() method.
    - The new methods buy() and sell() are added and are used by the processCommand() method.

The SpartanSoldier, Leader, Commander, Farmer, Developer, and Merchant classes all inherit from the Citizen base class. They all override the processCommand() method to provide their own functionality based on what is expected of their class, such as a Commander that can train or draft soldiers. They also add their own methods and fields to extend their functionality, such as being able to admit defeat or gloat depending on who won in combat in the case of the SpartanSoldier class. Inheritance allows the programmer to reuse previously written code. Because these derived classes inherit from the Citizen base class, they also inherit its fields such as the name or skill and can access them by calling the appropriate setters and getters. Thanks to inheritance as well, we can achieve polymorphism, as is the case in the Polis game mode of the program where one can simply call the processCommand() on a Citizen instance or any instance of its derived classes and it will work without any additional code. While Encapsulation aims to lessen the burden of complexity on the mind by abstracting and hiding code behind an easy to use interface, inheritance aims to lessen code repetition and reuse code that was already written.
