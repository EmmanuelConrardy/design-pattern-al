using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace Composite
{
    public class CompositeTest
    {
        [Fact]
        public void Composite_Without_Design()
        {
            //Arrange
            List<Composant> TracteurComposants = new List<Composant>();
            Remorque maRemorque = new Remorque(poids: 11);
            Tracteur monTracteur = new Tracteur(poids: 8);
            TracteurComposants.Add(maRemorque);
            TracteurComposants.Add(monTracteur);

            //Act
            var poid = TracteurComposants.Sum(c => c.GetPoids());

            //Assert
            Assert.Equal(19, poid);

            //Here the "Sum" line 18 is logical piece of code that should have a place.
            //Or you risk of break the "DRY" principle "Don't Repeat Yourself"
            //Use a composite Design too use this kind of functionnality.
        }

        [Fact]
        public void Composite_With_Design()
        {
            //Arrange
            Remorque maRemorque = new Remorque(poids:11);
            Tracteur monTracteur = new Tracteur(poids:8);
            CamionComposite semiRemorque = new CamionComposite();
            semiRemorque.Add(maRemorque);
            semiRemorque.Add(monTracteur);

            //Act
            var poid = semiRemorque.GetPoids();

            //Assert
            Assert.Equal(19,poid);
        }
    }

    //Interface of the elements/composite
    //Define functionnalities needed for our composite pattern
    public interface Composant
    {
        int GetPoids();
    }

    //Leaf
    public class Remorque : Composant
    {
        private int poids;

        public Remorque(int poids)
        {
            this.poids = poids;
        }

        public int GetPoids()
        {
            return this.poids;
        }

    }

    //leaf
    public class Tracteur : Composant
    {
        private int poids;

        public Tracteur(int poids)
        {
            this.poids = poids;
        }

        public int GetPoids()
        {
            return this.poids;
        }
    }

    //composite / elements of our structure
    public class CamionComposite : Composant
    {

        private List<Composant> children;

        public CamionComposite()
        {
            children = new List<Composant>();
        }


        public void Add(Composant composant)
        {

            children.Add(composant);
        }


        public void remove(Composant composant)
        {
            children.Remove(composant);
        }

        public List<Composant> getChildren()
        {
            return children;
        }

        public int GetPoids()
        {
            return children.Sum(c => c.GetPoids());
        }
    }
}
