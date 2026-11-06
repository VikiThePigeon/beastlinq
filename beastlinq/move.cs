using System;
using System.Collections.Generic;

//абстрактний клас мува наслідники будуть атаки і хілки а ще тільки вони будуть реалізовувати метод юз
public abstract class Move : IShowable
{
   //можна прочитати ззовні але змінити лише в самому класі
   public string Name { get; private set; }
   public int Power { get; private set; }
   public Move(string name, int power )
   {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Назва ходу не може бути порожньою.");
        if (power < 0)
            throw new ArgumentException("Сила ходу не може бути від'ємною.");
        Name = name;
        Power = power;
   }
    //метод абстрактний: реалізації тут немає, кожен наслідник зобов'язаний написати свою
    public abstract void Use(Creature user, Creature target);

    public virtual void Show()
    {
        Console.WriteLine(Name + " (strength: " + Power + ")");
    }

}
