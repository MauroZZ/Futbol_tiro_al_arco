# 🎮 Trabajo 3 - Minijuego de Fútbol: Tiro al Arco

> **Ubicación del juego compilado:**  
> El juego está disponible en la carpeta `Assets/JuegoComprimido` dentro del proyecto Unity, listo para ser ejecutado o comprimido.

---

## ✅ Avances logrados

### ⚽ Escenario, portería y balón
- Cancha de fútbol modelada en 3D con texturas aplicadas.
- Portería con capacidad de movimiento horizontal (eje Z) mediante script.
- Balón modelado en 3D, posicionado en el centro del escenario.

### 🎥 Cámara y control de dirección
- La cámara sigue a la pelota desde atrás y ligeramente elevada.
- Antes de disparar, el jugador puede mover la cámara horizontalmente con el mouse para apuntar.
- Al iniciar el juego, la cámara se posiciona automáticamente mirando hacia el arco.

### 🧩 Menú interactivo (UI)
Se implementó un menú principal y una pantalla de opciones utilizando el sistema de UI de Unity, accesibles al iniciar el juego.

#### 🎮 Menú Principal
- Campo para ingresar el nombre del jugador (`InputField`).
- Botón para iniciar el juego.
- Botón para abrir el menú de opciones.

#### ⚙️ Pantalla de Opciones
- Texto explicativo sobre la usabilidad y objetivo del juego.
- `Toggle` para activar la dificultad:
  - Desactivado (por defecto): la portería permanece estática.
  - Activado: la portería se mueve de un lado a otro, aumentando la dificultad.
- `Slider` para controlar el volumen de la música ambiental.
- Botón para volver al menú principal.

### 🔊 Música ambiental
- Se agregó una pista de música de fondo en el menú.
- El `Slider` permite ajustar el volumen desde el 0% hasta el 100%.
- Al iniciar el menú, el volumen comienza en 10% por defecto para evitar un sonido abrupto.

### 🧠 Dificultad y movimiento del arco
- El `Toggle` en el menú controla la variable `modoDificil`.
- Esta variable se utiliza en la escena de juego para determinar si el arco debe moverse.
- En modo difícil, el arco se mueve automáticamente en el eje Z de forma oscilante usando `Mathf.Sin()`.

### 🥅 Detección de goles
- Se implementó la detección de goles utilizando un panel invisible con `Collider` y `isTrigger` dentro de la portería.
- Al entrar la pelota (con tag `Pelota`) al área de gol, se imprime un mensaje en consola (`Debug.Log("¡GOL!")`).
- Todo el sistema de detección de gol está gestionado desde el script `DetectorGol.cs`.
- ✅ Se muestra un **contador de goles en pantalla**: `Goles: X / 3`, actualizado en tiempo real.

### 💥 Efectos de sonido y partículas
- 🔊 Sonido de disparo al lanzar la pelota.
- 🔊 Sonido de gol al anotar.
- 🎆 Al lograr 3 goles, se activa un efecto visual con **fuegos artificiales** mediante `ParticleSystem`.
- 🎉 También se reproduce un sonido especial de celebración junto con el panel de victoria.

### 🏆 Pantalla de victoria al ganar
- Cuando el jugador anota 3 goles, aparece un panel de victoria que indica que ha ganado la partida.
- El panel incluye un mensaje personalizado con el nombre del jugador ingresado previamente en el menú.
- Este mensaje se actualiza dinámicamente con la variable `MenuManager.nombreJugador`.
- Se activa un botón para **volver al menú principal** utilizando `SceneManager.LoadScene("MenuPrincipal")`.
- También se incluye un botón para **reintentar el juego**, recargando la escena actual.
- La música del menú se detiene correctamente si se vuelve desde esta pantalla para evitar que se superponga.

### ❌ Detección de fallos al tocar las paredes
- Se agregaron `BoxCollider` con `isTrigger` a las paredes laterales.
- Si la pelota (con tag `Pelota`) toca una de las paredes, se considera un fallo y se **descuenta un punto**.
- Se imprime un mensaje en consola indicando el fallo (`Debug.Log("Fallaste!")`) y se reinicia la pelota.

### 🖼️ Imagen de fondo en UI
- Se agregó una imagen de fondo en el Canvas del menú principal y la pantalla de victoria.
- La imagen se extiende automáticamente para cubrir toda la pantalla mediante configuración del `RectTransform`.
- El fondo se ubica detrás de todos los elementos UI para mejorar la presentación visual del menú.

---

## 👨‍💻 Desarrolladores
- Mauro  
- Jonnathan
