# APUNTS OPTATIU

## CONCEPTES API

```
- Fitxers Compartit
- RPC 
- Sockets (en tiempo real varias personas ven la informacion) i protocols propis
- AJAX(permite cambiar una parte de la pagina web, aprte dinamica i otra estatica).
- Aplicacions web canvien informació sobre HTTP(s) - Protocol Standar
- El canvi de paradigma: APIs sobre HTTP


    IDEAS
        informacion tiempo real
        utilizar protocolos http https para conectar cliente servidor
        las apis no tienes memoria simplemente responde las peticiones hechas por el cliente


    INTERFICIE UNIFORME
        Los recuersos se manipulan siempre de la misma forma
        una vez hecha el pedido al servidor puede haber dos opciones 
            1. Te devuele la informacion pedida en un JSON
            2. Da error
                200 todo ok
                404 not found
                500 internal error
    
    SISTEMA EN CAPAS 
        Entre cliente i server hay multiples capas 
            Cache és un server intermedario que guarda peticiones y sus respuestas para
            evitar la carga en el servidor principal

    CODE ON DEMAND opcional
        El server envia tb un codi ejecutable por ejemplo el javascript
```

```
 Recursos de l'API 
- Ús dels verbs HTTP (GET(Read),POST(Create),PUT/PATCH(Update),DELETE)
- Recursos identificats amb URLs (/user ; /user/1 ; /user/1/orderes/5)

Estructura

Verb (GET, PUT,...) + URL

Representació dels recursos amb JSON  (retorna un JSON amb les dades)


(servidor de Caché)



```
rest
Code on Demand

# Disseny APIs

## **Paràmetres**
    
### **Path**
```
    - Formen part de la ruta URL.
    - S'usen per identiricar un recurs.

    - Exeples:

        * `/users`
        * `/users/{id}` => `/users/5/orders`
```
### **Query**
```
    - S'afageixen al final de la URL després del ?.
    - S'usen per filtrar, ordenar o modificar la resposta, no per identificar un recurs únic.

    - Exemples:
        * `/users?sort=desc&limit=10`
        * `/users/5/orderse?status=pending`

```
## **Path vs Query parameters**

Podem utilitzar `/users/5/orders?status=pending` o `/users/5/orders/pending`


# Token Based (JWT)

# OAuth2
- Protocol d'autorització delegada.
- Com funciona (simplificant):
    - Un usuari es valida en un proveïdor de confiança(Goolge, GitHub...).
    - El proveïdor dona un token al client per accedir a l'API.
- Pros
    - Molt segur: evita guradar contrasenyes a apps terceres.
- Contres
    - Més complex d'implementar.
