//This controls the behaviour of each square such as what image to display

using System.Drawing;

namespace FindTweety
{
    class Square
    {
        private Graphics graphics;
        private Rectangle bounds;
        private Image image;
        private Status type;

        public Square(Graphics graphics, Image image, Rectangle bounds)//constuctor
        {
            this.graphics = graphics;
            this.image = image;
            this.bounds = bounds;
        }

        public bool FindActiveSquare(Point mouseLocation)//finding what square should be display according to the mouse location
        {
            bool foundSquare = false;

            if (bounds.Contains(mouseLocation) == true)
            {
                foundSquare = true;
            }
      
            return foundSquare;
        }

        private void Draw()//displaying the image on the form
        {
            graphics.DrawImage(image, bounds.Left, bounds.Top);
        }

        public void Play()//setting the image according to its status
        { 
            switch (type)
            {
                case Status.win:
                    {
                        image = Properties.Resources.tweety;
                        break;
                    }
                case Status.lose:
                    {
                        image = Properties.Resources.sylvester;
                        break;
                    }
                case Status.blank:
                    {
                        image = Properties.Resources.blue;
                        break;
                    }
            }
            Draw();
        }

        public void NewGame()//setting the image to the starting image
        {
            image = Properties.Resources.start;
            Draw();
        }

        internal Status Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }
    }
}
