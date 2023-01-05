
Vue.component('charttitle', {
    data() {
        return {
            message: 'TABLE TITLE',
            collapsed: true
        }
    },
    template: `
<div id ="chart_title">
    <label>
    <input v-model="message" placeholder="Insert the chart title" v-bind:class="[ {'is-collapsed' : collapsed }, 'inputHide' ]" type="text">
    </label>
    <h2>{{ message }} <button class="hideshow" v-on:click=" collapsed = !collapsed"><i class="fa fa-pencil" aria-hidden="true"></i></button></h2>
  </div>
`
})

/* Second header */

Vue.component('chartsubtitle', {
    data() {
        return {
            message: 'Data reports',
            collapsed: true
        }
    },
    template: `
<div id ="chart_subtitle">
    <label>
    <input v-model="message" placeholder="Insert the chart title" v-bind:class="[ {'is-collapsed' : collapsed }, 'inputHide' ]" type="text">
    </label>
    <h2>{{ message }} <button class="hideshow" v-on:click=" collapsed = !collapsed"><i class="fa fa-pencil" aria-hidden="true"></i></button></h2>
  </div>
`
})


Vue.component('charttable2', {
    props: ['proplabels'],
    data() {
        return {
            disabled: true
        }
    },
    methods: {
        deleteEvent: function (index) {
            this.proplabels.splice(index, 1);
            console.log(index);
            if (i == -1) {
                vm.value = srv_vm.getprice;
                console.log(srv_vm.labels.length);
                vm.num = srv_vm.labels.length;
                console.log($('#Uvalue').val());
               // vm.labels[i].isedit = true;
            }
            else {
                vm.labels[i].value = srv_vm.getprice;
                vm.labels[i].num = srv_vm.labels.length;
                console.log($('#Uvalue').val());
                vm.labels[i].isedit = true;
            }
            
        },
         changesprice: function() {
    console.log(i);
    if(i == -1) {
    console.log($('#Uvalue').val());
    console.log($('#totalprice').val());
    vm.value = $('#totalprice').val();
} else {
    vm.labels[i].value = srv_vm.getprice;
}
}
    },
    template:
        `

<div id="chart_table">
          <div>

<table class="table align-middle gs-0 gy-4 table100">
  

<tbody>
    <div v-for="(val, index)al in proplabels" >
<tr>
<td> 
 <input style="width:2rem" type="text" v-bind:value="index+1" disabled></input>
      </td>
<td> 
       
            <input type="text" v-model="val.serv" > </input>
        
    </td>
    <td>   
        
            <input type="text" v-model="val.price" v-on:change="changesprice()"> </input>
        
    </td>
    <td>   
        
            <input type="text" style="width:3rem" v-model="val.sqty" > </input>
        
    </td>
    <td>
        
            <button   @click="deleteEvent(index)">
                <i class="fa fa-times" aria-hidden="true"></i>
            </button>
        
    </td>
</tr>
</div>
</tbody>

</table>
</div>
</div>

`
})


var srv_vm = new Vue({
    el: '#kt_modal_sercices_form32',
    data: {
        serv: '',
        price: '',
        sqty:1,
        label: '',
        copay: '',
        labels: vm.srv,
        nextBarId: 1
    },
    computed: {
        getprice: function () {

            let total = 0;
            this.labels.forEach(function (val) {
                total += (+val.price) ;
            });
            return total.toFixed(2);
        },
        
    },
    methods: {
        addRow: function (event) {
            lastId = this.labels.length;
            var newRow = {
                id: this.nextBarId++,
                sqty: this.sqty,
                servid: $('#servid').find('option:selected').val(),
              
                serv: $('#servid').find('option:selected').text().trim(),
                price: this.price
            };
            console.log("in added");

            if (i == -1) { vm.srv.push(newRow); }
            else { vm.labels[i].srv.push(newRow) }
            
           // this.labels.push(newRow);
            $('#servid').focus();
            //console.log($('#servid').find('option:selected').text().replace("\n", "").trim())
            this.clearser();
            $('#servid').focus();
            toastr.options = {
                "closeButton": false,
                "debug": false,
                "newestOnTop": false,
                "progressBar": false,
                "positionClass": "toast-top-right",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            };

            toastr.success("Your work on Add has been saved.");
           
        },
        checkyk: function (e) {
           // console.log(this.price)
            var KeyID = (window.event) ? event.keyCode : e.keyCode;
            if (KeyID == 13 && this.price != "") {  $('#addservsbu').focus();}

        },
        clearser: function () {
            this.price = "";
            this.sqty = 1;
            $('#servid').val([]).trigger('change');
            
            setTimeout(function () {
                $('#servid').click();
                $('#servid').select2("focus");
            }, 800);
           
        }

    }
});






