namespace ECommerceFrontend.Models
{
    internal class PrimaryKeyAttribute : Attribute
    {
        private string v1;
        private string v2;

        public PrimaryKeyAttribute(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}