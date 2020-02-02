//pattern 1. Strategy
// поведенческий паттерн, выносит набор алгоритмов в
// собственные классы и делает их взаимозаменимыми

using System;

class MainClass {
  public static void Main (string[] args) {
    RealDuck duck = new RealDuck();
    duck.Hello();
    duck.Swim();
    duck.SetSwim(new SwimDisability());
    duck.Swim();

    Console.WriteLine();

    WoodenDuck woodenDuck = new WoodenDuck();
    woodenDuck.Hello();
    woodenDuck.Fly();
  }
}


//Swimming Strategy
public interface ISwim{
  void Swim();
}

//Strategy 1
public class SwimAbility:ISwim{
  public void Swim(){
    Console.WriteLine("I can swim!");
  }
}

//Strategy 2
public class SwimDisability:ISwim{
  public void Swim(){
    Console.WriteLine("I can't swim!");
  }
}





//Flying Strategy
public interface IFly{
  void Fly();
}

//Strategy 1
public class FlyAbility:IFly{
  public void Fly(){
      Console.WriteLine("I can fly!");
    }
}

//Strategy 2
public class FlyDisability:IFly{
  public void Fly(){
      Console.WriteLine("I can't fly!");
    }
}


//basic class
public class Duck{
  public IFly ifly;
  public ISwim iswim;

  public void Fly(){
    ifly.Fly();
  }

  public void Swim(){
    iswim.Swim();
  }

  public void SetSwim(ISwim _iswim){
    iswim = _iswim;
  }

  //common part
  public void Hello(){
    Console.WriteLine("Hello there!");
  }
}


//inheritor 1 
public class RealDuck:Duck{
  public RealDuck(){
    ifly = new FlyAbility();
    iswim = new SwimAbility();
  }
}

//inheritor 2 - disabled
public class WoodenDuck:Duck {
  public WoodenDuck(){
    ifly = new FlyDisability();
    iswim = new SwimDisability();
  }
}
