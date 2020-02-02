//pattern 2. Observer
// поведенческий паттерн, который позволяет объектам оповещать
//другие объекты об изменениях своего состояния. 
//связь один-ко-многим

using System;
using System.Collections;

class MainClass {
  public static void Main (string[] args) {
    Console.WriteLine ("Hello World");

    WeatherStation wStation = new WeatherStation();
    SmartPhone phone = new SmartPhone(wStation);
    WebSite site = new WebSite(wStation);

    wStation.Add(phone);
    wStation.SetTemperature(12.3);
    wStation.Add(site);
    wStation.SetTemperature(13.2);
    wStation.Remove(phone);
    wStation.SetTemperature(11.9);

  }
}


public interface IObservable{
  void Add(IObserver iobv);
  void Remove(IObserver iobv);
  void Notify();
}

public interface IObserver{
  void Update();
}

public interface IDisplay{
  void Display();
}



//Subject
class WeatherStation:IObservable{
  ArrayList observers = new ArrayList();
  double temperature;
  
  public void Add(IObserver iobv){
    this.observers.Add(iobv);
  }

  public void Remove(IObserver iobv){
    this.observers.Remove(iobv);
  }

  public void Notify(){
    foreach (IObserver iobv in this.observers)
      iobv.Update();
    }

  public double GetTemperature(){
    return this.temperature;
  }

  public void SetTemperature(double _temp){
    this.temperature = _temp;
    Notify();
  }
}



//observer1
class SmartPhone:IObserver, IDisplay{
  WeatherStation wStation;
  double temperature;
  
  public void Update(){
    this.temperature = this.wStation.GetTemperature();
    Display();
  }

  public void Display(){
    Console.WriteLine($"T on SmartPhone: {temperature}");
  }

  public SmartPhone(WeatherStation _wStation){
    this.wStation = _wStation;
  }
}


//observer2
class WebSite:IObserver, IDisplay{
  WeatherStation wStation;
  double temperature;
  
  public void Update(){
    this.temperature = this.wStation.GetTemperature();
    Display();
  }

  public void Display(){
    Console.WriteLine($"T Widget on WebSite: {temperature}");
  }

  public WebSite(WeatherStation _wStation){
    this.wStation = _wStation;
  }
}
