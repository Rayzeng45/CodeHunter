using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //SE REQUIERE A�ADIR ESTA LIBRER�A MANUALMENTE YA QUE NO VIENE CARGADA POR DEFECTO. SU FUNCI�N ES QUE, CONTROLA LAS ESCENAS.

public class BotonesMenu : MonoBehaviour
{
    [SerializeField] private GameObject botonpausa; //Crea un campo interactuable llamado "botonpausa" en la secci�n del script dentro del editor del juego (En este caso donde habr� que arrastrar y soltar el elemento que contenga el bot�n que pause el juego)
    [SerializeField] private GameObject menupausa; //Crea un campo llamado "menupausa" donde ir� en este caso insertado el objeto que contenga el fondo del men� de pausa junto con sus botones.

    //AVISO: El script utilizado para controlar el men� in-game es el mismo que el que se utiliza en el men� principal, por lo que estas dos casillas tambi�n aparecer�n en el campo del script insertado al bot�n de iniciar juego (ya que, obviamente, es el mismo script en ambas escenas) Sin embargo no tendr�n utilidad alguna, por lo que no debe tocarse. Se entender� mejor m�s adelante.
    /////////////////////////////////////////////////////////////////////////////////////////////////////////
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject ConfigurationMenu;
    [SerializeField] private GameObject Creditos;
    [SerializeField] private GameObject SeleccionarMundo;
    /////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void Pausar() //M�todo que pausa el juego.
    {

        Debug.Log("Acci�n: Menu Pausa"); //Env�a un mensaje debug a la consola, no afecta nada en el juego.
        Time.timeScale = 0f; //Establece el paso del tiempo dentro del juego a 0, es decir, estar� totalmente pausado.
        botonpausa.SetActive(false); //El campo que creamos antes, el elemento que hayamos arrastrado dentro, lo volver� "inactivo", lo ocultar�.
        menupausa.SetActive(true); //Reactivar� el elemento dentro del campo llamado "menupausa" si este estaba inactivo.

        //Con este c�digo se puede entender que, cuando se ejecuta el m�todo "Pausar", el tiempo del juego es establecido en 0. luego, el bot�n que se presion� para acceder al men� desaparecer�, ya que si, estando en el editor, se arrastr� este elemento (Bot�n de pausa) a la casilla "botonpausa" del campo de este script que ha sido creado con "SerializeField", y el cual indica que su visibilidad ser� desactivada (SetActive(false)), ocurrir� esto. A su vez, aparecer� el panel del men� de pausa, ya que si se arrastr� a la casilla "menupausa" el elemento que contiene el panel del men� de pausa donde est�n todos los botones, aparecer� porque se le indic� que establezca su visivilidad en true (Por defecto el panel tiene que tener la visivilidad desactivada, lo cual se puede hacer desde el editor).


    }

    public void Reanudar()  //Este m�todo reanudar� el juego si este se encontraba pausado.
    {

        Debug.Log("Acci�n: Menu Pausa");
        Time.timeScale = 1f; //Establece el tiempo del juego en 1, lo cual significa que correr� a velocidad normal.
        botonpausa.SetActive(true); //Establecer� la visibilidad de lo que haya en la casilla llamada "botonpausa" en true (Habiendo le�do lo anterior, deber�a estar insertado el elemento del bot�n que alterna el men� de pausa estando in-game)
        menupausa.SetActive(false); //Establece la visivilidad del panel del men� en false (Si es que el elemento del panel de pausa, que contiene todos los botones, ha sido arrastrado a la casilla "menupausa" del campo de este script antes)


    }
    public void Play() //M�todo que se usa en la escena del men� principal para poder iniciar el juego.
    {
        SceneManager.LoadScene(3); //Le indica al gestor de escenas que debe cargar la escena 1, en la escena 1 se ubica el juego de testeo.
        Time.timeScale = 1f; //El tiempo es establecido a 1 (En marcha) al comenzar el juego porque, si se sali� al men� mediante el bot�n de ir al men�, el cual se encuentra en el men� de pausa, esto significa que se paus� el juego antes, por lo que el tiempo permanecer� en 0 hasta que por medio de otra l�nea de c�digo sea establecido a 1. Si se entra al juego despu�s de haber salido desde el men� y sin establecer el tiempo a 1, este seguir� pausado porque seguir� en 0 desde la vez que se sali� al men�.

    }

    public void StopPlay() //M�todo que se usa in-game, encontrado en el bot�n de salir cuando se alterna el men� de pausa.
    {

        SceneManager.LoadScene(0); //Le indica al gestor de escenas que cargue la escena 0. En esta escena se ubica el men� de inicio.
    }

    public void SelectWorld() //SELECCIONAR MUNDO
    {
        MainMenu.SetActive(false);
        SeleccionarMundo.SetActive(true);
        Debug.Log("Boton Selecci�n Niveles");

    }

    public void ConfigurationsMenu() //CONFIGURACIONES
    {
        MainMenu.SetActive(false);
        ConfigurationMenu.SetActive(true);
    }

    public void VolverDeConfiguraciones() //(VOLVER DE CONFIGURACIONES)
    {
        MainMenu.SetActive(true);
        ConfigurationMenu.SetActive(false);
        Debug.Log("Boton Volver al menu principal");
    }

    public void VolverDeSeleccion() //(VOLVER DE SELECCI�N DE NIVELES)
    {
        MainMenu.SetActive(true);
        SeleccionarMundo.SetActive(false);
    }
}
