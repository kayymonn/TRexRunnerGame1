using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Graphics
{
    public class SpriteAnimationFrame
    {
        private Sprite _sprite;
        
        public Sprite Sprite 
        { 
          get 
          {
               return _sprite; 
          }
          
          set 
          { 
               if(value == null)
                    throw new ArgumentNullException("value", "The sprite cannot be null.");
                
                _sprite = value; 
          }  
            
            
            
   
         
        }




    }
}
