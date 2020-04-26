using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComDemoProject
{
    enum Direction
    {
        AB=0,
        BA=1
    }

    class PortOrder
    {
        private Direction direction;
        private string order;
        private string childAdress;
        private string adressCount;
        private string adressPoint;
        public string overPoint="0D0A";

        public PortOrder() { }

        public PortOrder(Direction d,string Order,string cAdress,string aCount,string aPoint) {
            direction = d;
            order = Order;
            childAdress = cAdress;
            adressCount = aCount;
            adressPoint = aPoint;
        }

        public Direction Direction
        {
            get
            {
                return direction;
            }

            set
            {
                direction = value;
            }
        }

        public string Order
        {
            get
            {
                return order;
            }

            set
            {
                order = value;
            }
        }

        public string ChildAdress
        {
            get
            {
                return childAdress;
            }

            set
            {
                childAdress = value;
            }
        }

        public string AdressCount
        {
            get
            {
                return adressCount;
            }

            set
            {
                adressCount = value;
            }
        }

        public string AdressPoint
        {
            get
            {
                return adressPoint;
            }

            set
            {
                adressPoint = value;
            }
        }

        public string getConnOrder()
        {

            return Direction+Order+ChildAdress+AdressCount+AdressPoint+overPoint;
        }
    }
}
