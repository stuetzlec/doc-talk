
namespace PipelineCore
{
    
    public class CharacterController
    {
        private CharacterControl control;

        public CharacterController(CharacterControl control)
        {
            this.control = control;
        }

        public void PerformResponse(ResponseMessage response)
        {
            control.PerformResponse(response);
        }
    }
}