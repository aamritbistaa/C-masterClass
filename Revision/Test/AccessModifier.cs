using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Test
{
    //* Virtual means new functionality for same method can be given
    //* Sealed means the child of that class can only access the method but cannot change the functionality
    //* override means giving new functionality
    //* abstract means, that method must be implemented, or overriden in child method

    public abstract class Messaging
    {

        public virtual void SendMessage()
        {
            System.Console.WriteLine("Important message sent from the server");
        }
        public void SayHelloWorld()
        {
            System.Console.WriteLine("Hello world");
        }
        public abstract void DescriptionInChild();
    }

    public class TextMessage : Messaging
    {
        public override void SendMessage()
        {
            System.Console.WriteLine("This is text message, sent from the server");
        }
        public override void DescriptionInChild()
        {
            System.Console.WriteLine("This is the description in Text Class for Message Description method.");
        }
    }
    public class EmailMessage : Messaging
    {
        public override void SendMessage()
        {
            System.Console.WriteLine("Email message sent from server");
        }
        public sealed override void DescriptionInChild()
        {
            System.Console.WriteLine("This is the description in Email Class for Message Description method.");
        }


    }

    public class EmailMessagePartner : EmailMessage
    {
        public override void SendMessage()
        {
            base.SendMessage();
            System.Console.WriteLine("Hello Partner");
        }
        /*
        THis throws error as this has been marked as sealed 
        public sealed override void DescriptionInChild()
        {

        }
        */
    }

    public class EmailMessageCustomer : EmailMessage
    {
        public override void SendMessage()
        {
            base.SendMessage();
            System.Console.WriteLine("Hello Customer");
        }

    }
    public class AccessModifier
    {
        public void MainFunction()
        {
            EmailMessageCustomer customer = new();
            customer.SendMessage();

            EmailMessageCustomer partner = new();
            partner.SendMessage();

        }
    }
}