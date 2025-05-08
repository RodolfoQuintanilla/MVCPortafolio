using app.Models;

namespace app.Servicios
{

    public interface IRespositorioProyectos
    {
        List<Proyecto> ObtenerProyectos();
    }

    public class RepositorioProyectos : IRespositorioProyectos
    {
        public List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>() {
            new Proyecto()
                {
                Titulo="Amazon",
                Descripcion="Amazon es una de las empresas más grandes del mundo",
                Link="http://amazon.com",
            ImagenUrl="/img/amazon.PNG"
                },

                 new Proyecto()
                {
                Titulo="New York Time",
                Descripcion="Pagina de noticias en React",
                Link="https://www.nytimes.com/",
                ImagenUrl="/img/nyt .PNG"
                },

                 new Proyecto()
                {
                Titulo="Reddit",
                Descripcion="Red social",
                Link="https://www.reddit.com/",
                ImagenUrl="/img/reddit .png"
                },

                 new Proyecto()
                {
                Titulo="Steam",
                Descripcion="Amazon es una de las empresas más grandes del mundo",
                Link="https://store.steampowered.com/",
                ImagenUrl="/img/steam .png"
                },
        };
        }
    }
}