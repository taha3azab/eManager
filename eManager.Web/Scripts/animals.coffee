class Animal
    constructor: (@name) ->

    speak: ->
        alert @name + " is speaking!"

dash = new Animal("Dash the cat")
dash.speak()