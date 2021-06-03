Vue.use(VeeValidate);

var app = new Vue({
    el: '#app',
    data: {
        modal: false,
        applications: [],
        application: {
            name: "",
            lastName: "",
            house: 0,
            state: 0,
            id: 0,
            documentNum: "",
            age: "",
            createdDate: "",
            updatedDate: ""
        },
    },
    methods: {
        send: function () {
            let success = this.errors.items.length == 0;
            if (!success) {
                alert("Hay errores en los campos del formulario.")
                return;
            }
            console.log(this.application)
            this.modal = false;
        },
        cancel: function () {
            this.application = {
                name: "",
                lastName: "",
                house: 0,
                state: 0,
                id: 0,
                documentNum: "",
                age: "",
                createdDate: "",
                updatedDate: ""
            };
            this.modal = false;
            this.load();
        },
        edit: function (application) {
            this.application = application;
            this.modal = true;
            //mandar a api
        },
        deleteApplication: function (application) {
            console.log("borrar", application)

            let callFunc = async function(apiURL) {
                let response = await fetch(apiURL,{method: 'POST'});
                let data = response;
                return data;
              }
            //obtener de api
            callFunc('https://localhost:44377/api/inscription/delete?id='+application.id).then(data => {
                // Ya dentro, podemos trabajar los datos
                console.log(data);
                this.load();
              }).catch(error => {console.log(error)});//en caso de algún error
            
            //mandar a api       
        },
        changeState: function (application, state) {
            application.state = state;
            console.log("cambiar a estado", state, application);
            let callFunc = async function(apiURL) {
                let response = await fetch(apiURL,{method: 'POST'});
                let data = response;
                return data;
              }
            //obtener de api
            callFunc('https://localhost:44377/api/inscription/changestate?id='+application.id+'&stateId='+state).then(data => {
                // Ya dentro, podemos trabajar los datos
                console.log(data);
                this.load();
              }).catch(error => {console.log(error)});//en caso de algún error
            //mandar a api
        },
        load: function () {
            let callFunc = async function(apiURL) {
                let response = await fetch(apiURL);
                let data = response.json();
                return data;
              }
            //obtener de api
            callFunc('https://localhost:44377/api/inscription/get').then(data => {
                // Ya dentro, podemos trabajar los datos
                console.log(data);
                this.applications = data;
              }).catch(error => {console.log(error)});//en caso de algún error
        }
        
    },
    created() {
        this.load();
    }


})