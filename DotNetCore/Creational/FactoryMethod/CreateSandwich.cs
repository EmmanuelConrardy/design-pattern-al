using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FactoryMethod
{
    public class CreateSandwich
    {
        #region WithoutDesign
        [Fact]
        public void Without_Design()
        {
            var ingredients = new List<Ingredient>();
            ingredients.Add(new Bread());
            ingredients.Add(new Mayonnaise());
            ingredients.Add(new Lettuce());
            ingredients.Add(new Turkey());
            ingredients.Add(new Turkey());
            ingredients.Add(new Bread());

            var turkeySandwich = new TurkeySandwich(ingredients);

            //Its not good the ingredients should be not create appart of the sandwich
            //here we have dispatch the responsability of the sandwich creation
            //Look at the with_design region and try to refactor this test
        }

        public class TurkeySandwich
        {
            private List<Ingredient> _ingredients;

            public TurkeySandwich(List<Ingredient> ingredients)
            {
                _ingredients = ingredients;
            }
        }

        #endregion 

        #region WithDesign
        [Fact]
        public void With_Design()
        {
            var CheeseSandwich = new CheeseSandwich();

            var MayoSandwich = new MayonnaiseSandwich();

            //All is create in once ! it is easy to create a lot of sandwich
        }
        public abstract class Sandwich
        {
            protected List<Ingredient> _ingredients = new List<Ingredient>();
            public Sandwich()
            {
                //A method in the contructor -> factory method
                CreateSandwich();
            }

            protected virtual void CreateSandwich() { }
        }

        public class CheeseSandwich : Sandwich
        {
            protected override void CreateSandwich()
            {
                _ingredients.Add(new Bread());
                _ingredients.Add(new Mayonnaise());
                _ingredients.Add(new Lettuce());
                _ingredients.Add(new Turkey());
                _ingredients.Add(new Turkey());
                _ingredients.Add(new Bread());
            }
        }

        public class MayonnaiseSandwich : Sandwich
        {
            protected override void CreateSandwich()
            {
                _ingredients.Add(new Bread());
                _ingredients.Add(new Mayonnaise());
                _ingredients.Add(new Bread());
            }
        }

        #endregion
    }

    public abstract class Ingredient { }

    public class Bread : Ingredient { }
    public class Turkey : Ingredient { }
    public class Lettuce : Ingredient { }
    public class Mayonnaise : Ingredient { }
}
