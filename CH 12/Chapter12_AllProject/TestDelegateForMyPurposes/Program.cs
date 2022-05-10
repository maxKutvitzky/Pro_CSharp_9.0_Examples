using System;
using TestDelegateForMyPurposes;

/*Subscriber subscriber1 = new Subscriber();
Subscriber subscriber2 = new Subscriber();
DAOHandler daoHandler = new DAOHandler();
daoHandler.AddSubscriber(subscriber1.DoSmt);
daoHandler.AddSubscriber(subscriber2.DoSmt);
DAO DAO = new DAO(daoHandler);
DAO.AddSomeThing(new DBInstance());
daoHandler.RemoveSubscriber(subscriber1.DoSmt);
daoHandler.RemoveSubscriber(subscriber2.DoSmt);*/

DBInstance instance = new DBInstance();

UIElement uIElement = new UIElement("Initial UIElement state");

Console.WriteLine($"UIElement state: {uIElement.State}");

Subscriber subscriber = new Subscriber(uIElement);

DAO dao = new DAO();

dao.Update += subscriber.DoSmt;

dao.AddSomeThing(instance);

Console.WriteLine($"UIElement state: {uIElement.State}");
