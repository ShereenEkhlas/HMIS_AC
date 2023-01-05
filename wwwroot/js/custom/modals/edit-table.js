

var batch_id = document.getElementById('ubatch_id').value;

Vue.component('charttitle', {
    data() {
        return {
            message: 'TABLE TITLE',
            collapsed: true,
           
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


Vue.component('charttable', {
    props: ['proplabels'],
    data() {
        batch_id: document.getElementById('ubatch_id').value;
        
        return {
            disabled: false,
            autoplay: false,
            svendor: false,
           
        }
    }, 
    computed: {
       
    },
  
    methods: {
        KeyCheckv :function(e, index,x) {
            //alert(z);
            
            //i = e.row;
            //  i = z;
            var KeyID = (window.event) ? event.keyCode : e.keyCode;
           
            if(KeyID == 113) {
                i = index;
                console.log(this.proplabels[index].srv);
                //this.$refs["srv"][index].
                if (this.proplabels[index].srv == 0 || this.proplabels[index].srv.Length == 0) {
                    // alert("in");
                    let _ss = getselectedservs(x);
                    console.log(_ss);
                    srv_vm.labels = _ss;
                    this.proplabels[index].srv = _ss;
                }
                else { srv_vm.labels = this.proplabels[index].srv; }
                $('#smodal').click();
}
    },
       
        deleteEvent: function (index, inv_id) {
            console.log(index);
           
            const swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'btn btn-success',
                    cancelButton: 'btn btn-danger'
                },
                buttonsStyling: false
            })

            swalWithBootstrapButtons.fire({
                title: 'Are you sure?',
                text: "You won't be able to revert this!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Yes, delete it!',
                cancelButtonText: 'No, cancel!',
                reverseButtons: true
            }).then((result) => {
                if (result.isConfirmed) {
                    vm.labels.splice(index, 1);
                    //this.proplabels.$remove(index);
                    swalWithBootstrapButtons.fire(
                        'Deleted!',
                        'Your file has been deleted.',
                        'success'
                    )
                   
                    
                    $.ajax({
                        url: "/Batches/DeleteInv?inv=" + inv_id,
                        type: "POST",
                        dataType: "json",
                        cashe: false,
                        data: {inv: inv_id},
                        success: function (res) {
                            console.log(res);
                           
                           // 
                            return res.status;
                            
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            console.log("jqXHR : " + jqXHR + " text status : " + textStatus + " error : " + errorThrown);
                            alert("jqXHR : " + jqXHR + " text status : " + textStatus + " error : " + errorThrown);
                        }
                    });
                   
                   
                } else if (
                    /* Read more about handling dismissals below */
                    result.dismiss === Swal.DismissReason.cancel
                ) {
                    swalWithBootstrapButtons.fire(
                        'Cancelled',
                        'Your imaginary file is safe :)',
                        'error'
                    )
                }
            })
        


           
            
        }
        ,
        validateInpSrvr: function (_element) {
            //  this.proplabels.splice(index, 1);
            // alert('ss');
            $.ajax({
                url:  "/Batches/validateInv",
                type: "POST",
                dataType: "json",
                cashe: false,
                data: _element,
                success: function (res) {
                    console.log(res);
                    return res.status;
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    console.log("jqXHR : " + jqXHR + " text status : " + textStatus + " error : " + errorThrown);
                    alert("jqXHR : " + jqXHR + " text status : " + textStatus + " error : " + errorThrown);
                }
            });
            console.log(index);
            this.proplabels[index].service_code = 554;
            this.$refs["rsercode"][index].focus()
        }
        ,
        validateInpt: function (index) {
            //  this.proplabels.splice(index, 1);
            // alert('ss');
            saveInvoice(this.proplabels[index]);
           // var moveNxt =this.validateInpSrvr(this.proplabels[index]);
         //   console.log(index);
           // this.proplabels[index].service_code = 554;
            //if (moveNxt)
            //    this.$refs["rsercode"][index].focus();
        }
        ,
        editRow: function (index) {
           // alert("in");
            //alert(this.$refs["service_date"][index].value < rdatec);
           // alert(this.$refs["service_date"][index].value + ' ' + rdatec);
            batch_id: document.getElementById('ubatch_id').value;
            if (this.proplabels[index].Approval_number == "" || this.proplabels[index].Approval_number.toString().length < 7) {
                this.$refs["Approval_number"][index].focus();
            }
            else if (this.proplabels[index].service_date == "" || this.$refs["service_date"][index].value > rdatec) {
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
                    "timeOut": "2000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                };

                toastr.error("Date is not Correct");
                this.$refs["service_date"][index].focus()
            }
            else if (this.proplabels[index].member_code == "") {
                this.$refs["rmember_code"][index].focus();
            }
             else if (this.service_code == "")

                this.$refs["service_code"][index].focus();

            else if (this.proplabels[index].med_item == "") {
                this.$refs["med_item"][index].focus();
            }
            //else if (this.insurance_med_item == "")
            //{
            //    $('#UIMeditem').focus();
            //}
            else if (this.proplabels[index].value == "") {
                this.$refs["value"][index].focus();
            }
            else if (this.proplabels[index].co_payment == "") {
                this.$refs["co_payment"][index].focus();
            }
            else if (this.proplabels[index].local_dis == "") {
                this.$refs["local_dis"][index].focus();
            }
          
           
            else if (this.proplabels[index].num == "") {
                this.$refs["num"][index].focus();
            }

            else {

                this.proplabels[index].isedit = false;
                editInvoice(this.proplabels[index]);
             
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

                toastr.success("Your work on Edit has been saved.");
                
            }

            //this.labels.push(this.proplabels[index]);
        },
        testM: function (mid, index) {
            if (mid != "") {
                console.log((this.proplabels[index].member_code));
                console.log((this.proplabels[index].service_date));

                Validat_Mem(mid, vm.labels[index].service_date, index);

            }
        },
        testMidi: function (mid, date, index) {
            if (this.proplabels[index].medI.length ==0) {
                console.log(54);
                i = index;
                Validat_Mem(mid, date, index);
            }
        },
        testSS: function (index, x) {
            
            i = index;
            console.log(this.proplabels[index].srv);
            //this.$refs["srv"][index].
            if (this.proplabels[index].srv == 0 || this.proplabels[index].srv.Length == 0) {
               // alert("in");
                let _ss = getselectedservs(x);
                console.log(_ss);
                srv_vm.labels = _ss;
                this.proplabels[index].srv = _ss;
            }
            else { srv_vm.labels = this.proplabels[index].srv;}
            $('#smodal').click();
          
           // this.$refs["med_item"][index].focus();
            //alert(i);
            //let serv = getService(mid);
            //if (index != -1) {
            //    console.log("from vue");
            //    vm.labels[index].service_code = serv.nm_code;
            //    vm.labels[index].contract_service_name = serv.nm_name;
            //    this.$refs["med_item"][index].focus();
            //}
           // this.contract_service_name 
            //    this.proplabels[index].contract_service_name = getService(mid);
            //this.$refs["med_item"][index].focus();
        },
        testS: function (mid, index) {
            //this.proplabels[index].last_update_by = mid;
           
            let serv = getService(mid);
            this.proplabels[index].service_code = serv.nm_code;
            this.proplabels[index].contract_service_name = serv.nm_name;
               
            this.$refs["med_item"][index].focus();
        },
        test_addbyApp: function (mid,index) {
            var bid = document.getElementById('ubatch_id').value;
          
            if (mid.toString().length == 11) {
                let inv = getDataByApp_Num(mid, bid);
                if (inv._status) {
                    this.proplabels[index].member_code = inv._inv.member_code;
                    this.proplabels[index].member_name = inv._inv.member_name;
                    this.proplabels[index].service_date = inv._inv.service_date;
                    this.proplabels[index].med_item = inv._inv.med_item;
                    this.proplabels[index].MedI_name = inv._inv.medI_name;
                    this.proplabels[index].srv = inv._inv.srv;
                    srv_vm.labels = inv._inv.srv;
                    this.proplabels[index].service_code = inv._inv.service_code;
                    this.proplabels[index].contract_service_name = inv._inv.contract_service_name;
                    this.proplabels[index].num = srv_vm.labels.length;
                    this.proplabels[index].value = srv_vm.getprice;


                    this.$refs["co_payment"][index].focus();
                }
            }
            else if (mid.toString().length < 7) {
                alert("Approval_number Must be more than 6,please check again !!.");
                this.$refs["Approval_number"][index].focus();
            }
            else {
                var c = check7apprval_number(mid,index);
                
                console.log(c);
              
                if (!c._status) { alert(c._msg); }
                else { this.$refs["service_date"][index].focus(); }
                
            }
        },
        KeyCheck: function (b, c,k) {
            KeyCheck(b, c,k);

        },
        mbackstep1: function (index) {
            this.$refs["Approval_number"][index].focus()
        },
        mbackstep2: function (index) {
            this.$refs["service_date"][index].focus()
        },
        mbackstep3: function (index) {
            this.$refs["rmember_code"][index].focus()
        },
        mbackstep4: function (index) {
            this.$refs["service_code"][index].focus()
        },
        mbackstep5: function (index) {
            this.$refs["med_item"][index].focus()
        },
        mbackstep6: function (index) {
            this.$refs["med_item"][index].focus()
        },
        mbackstep7: function (index) {
            this.$refs["value"][index].focus()
        },
        mbackstep8: function (index) {
            this.$refs["co_payment"][index].focus()
        },
        mbackstep9: function (index) {
            this.$refs["local_dis"][index].focus()
        },
        mbackstep11: function (index) {
            if (svendor == "true") {
                this.$refs["import_dis"][index].focus();
            }
            else {

                this.$refs["local_dis"][index].focus()
            }
           
        },
        //mbackstep11: function (index) {
        //    this.$refs["total_bvar"][index].focus()
        //},
        mbackstep12: function (index) {
            this.$refs["Rev_dis"][index].focus()
        },
        mbackstep13: function (index) {
            this.$refs["num"][index].focus()
        },


        move2: function (index) {
            let sd = this.$refs["service_date"][index].value;
            //alert(sd + ' ' + rdatec);
            if (sd != "" && sd < rdatec) { this.$refs["rmember_code"][index].focus(); }
        },

			 move5: function (index) {
               this.$refs["value"][index].focus();
        },
			 //move6: function (index) {
    //             this.$refs["value"][index].focus();
    //    },
			
			 move8: function (index) {
            this.$refs["co_payment"][index].focus();
        },
			 move9: function (index) {
            this.$refs["local_dis"][index].focus();
        },
        move10: function (index) {
            if (svendor == "true") {
                this.$refs["import_dis"][index].focus();
            }
            else {

                this.$refs["Rev_dis"][index].focus();
            }
            
        },
			 move11: function (index) {
                 this.$refs["Rev_dis"][index].focus();
        },
			 move12: function (index) {
                 this.$refs["Rev_dis"][index].focus();
        },
			move13: function (index) {
            this.$refs["num"][index].focus();
        },
			move14: function (index) {
            this.$refs["note"][index].focus();
        },
			move15: function (index) {
            this.$refs["edit"][index].focus();
        },

    },

    template:
        `


   



        <table >
            <thead style="display:none">
                <tr>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th> </th>
                    <th>  </th>
                    <th> </th>
                    <th> </th>
                    <th > </th>
                    <th v-if="svendor">  </th>
                    <th> </th>
                    <th> </th>
                    <th> </th>
                    <th> </th>
                    <th> </th>
                    <th> </th>
                    <th> </th>
                    <th> </th>
                </tr>
  </thead>
<tbody>
         

    <div v-for="(val, index)al in proplabels" >
<tr onclick="i=this.rowIndex" v-on:change="val.isedit=true">
    <td>
       
            <input style="width:2rem" type="text" v-model="val.serial" disabled></input>
 <input value="@Model.batch_id"  name="batch_id" hidden>
 
<input value="@Model.inv_id" v-model="val.inv_id" name="inv_id" hidden>
  
      
    </td> <td >
             
                 <input style="width:10rem"   v-on:keyup.enter="test_addbyApp(val.Approval_number,index)" ref="Approval_number"  data-kt-user-table-filter="approval_number" type="text" v-model="val.Approval_number"  > </input>
            
            </td> <td>
             
                 <input  style="width:12rem" v-on:keyup.enter="move2(index)" ref="service_date"  type="date" v-model="val.service_date" v-bind:class="" > </input>
           
            </td> <td>
       
            <input v-on:keyup.enter="testM(val.member_code,index)"  v-on:keyup="KeyCheck(this,index,1)" v-on:dblclick="KeyCheck(this,index,2)"  v-on:keyup.left="mbackstep2(index)" ref="rmember_code" type="text" data-kt-user-table-filter="member_code" v-model="val.member_code" v-bind:disabled="disabled" > </input>  
            <br />   <input style="margin-top:6px" type="text"  v-model="val.member_name"  value="" disabled> </input>
 <button data-bs-toggle="modal" data-bs-target="#kt_modal_new_target" id="mmodal" onclick="loadTarget" hidden></button>
       
    </td> <td>
       
            <input readonly  v-on:dblclick="testSS(index,val.inv_id)" v-on:keyup="KeyCheckv(this,index,val.inv_id)" v-on:keyup.left="mbackstep3(index)" type="text" ref="service_code" v-model="val.service_code" v-bind:disabled="disabled"> </input> 
            <br />   <input style="margin-top:6px" type="text"  v-model="val.contract_service_name"  value="" disabled> </input>
        
    </td> <td>
     
           <input type="text" v-bind:list="val.inv_id" ref="med_item" data-allow-clear="true" @focus="testMidi(val.member_code,val.service_date,index)" style="width:10rem" v-on:keyup.left="mbackstep4(index)"   placeholder="select service item code" v-model="val.med_item" id="UMeditem" name="med_item" > </input>  
         <datalist v-bind:id="val.inv_id">
                                    <option v-for="option in val.medI" v-bind:value="option.id">
                                        {{option.name }}
                                    </option>
                                </datalist>
<br />   <input style="margin-top:6px;width:10rem" v-model="val.MedI_name" type="text"  value="" disabled> </input>
       </td>

<td> 
       
            <input readonly v-on:keyup.enter="move8(index)"  v-on:keyup.left="mbackstep6(index)" ref="value" v-model="val.value" style="width:5rem" type="text" > </input>
       
    </td> <td> 
       
            <input v-on:keyup.enter="move9(index)" v-on:keyup.left="mbackstep7(index)" ref="co_payment" style="width:5rem" type="text" v-model="val.co_payment" v-bind:disabled="disabled"> </input>
      
    </td> <td >

            <input  v-on:keyup.enter="move10(index)" v-on:keyup.left="mbackstep8(index)" ref="local_dis" style="width:5rem" type="text" v-model="val.local_dis" v-bind:disabled="disabled"> </input>
       
    </td> <td v-if="svendor">

            <input v-on:keyup.enter="move11(index)" v-on:keyup.left="mbackstep9(index)" ref="import_dis" style="width:5rem" type="text" v-model="val.import_dis" v-bind:disabled="disabled"> </input>
    
    </td> <td>  

            <input style="width:5rem" type="text"   v-bind:value=(+val.local_dis)+(+val.co_payment)+(+val.import_dis) disabled> </input>
        
    </td>

<td > 

            <input v-on:keyup.enter="move12(index)" v-on:keyup.left="mbackstep10(index)" ref="total_bvar" style="width:6rem;" type="text" v-model="val.total_bvar" v-bind:disabled="disabled"> </input>
        
    </td> <td>  

            <input v-on:keyup.enter="move13(index)" v-on:keyup.left="mbackstep11(index)" ref="Rev_dis" style="width:5rem" type="text" v-model="val.Rev_dis" v-bind:disabled="disabled"> </input>
        
    </td> <td> 

            <input style="width:6rem" type="text"   v-bind:value=((+val.value)-(+val.co_payment)-(+val.local_dis)-(+val.Rev_dis)) disabled> </input>
      
    </td> <td> 

            <input readonly v-on:keyup.enter="move14(index)" v-on:keyup.left="mbackstep12(index)" ref="num" style="width:5rem" type="text" v-model="val.num" v-bind:disabled="disabled"> </input>
      
    </td> <td>   
  <label>
            <input v-on:keyup.enter="move15(index)" v-on:keyup.left="mbackstep13(index)" ref="note" type="text" style="width:10rem" rows="1" v-model="val.note" v-bind:disabled="disabled" > 
     
  </label>
    </td> <td>

     
          <button  type="button" ref="edit" class="btn btn-light-success" v-bind:id="'b_'+val.inv_id" v-on:click="editRow(index);" :hidden="!val.isedit" v-on:keyup.enter="editRow(index);">
                            <span class="svg-icon svg-icon-2">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-save-fill" viewBox="0 0 16 16">
                                    <path d="M8.5 1.5A1.5 1.5 0 0 1 10 0h4a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V2a2 2 0 0 1 2-2h6c-.314.418-.5.937-.5 1.5v7.793L4.854 6.646a.5.5 0 1 0-.708.708l3.5 3.5a.5.5 0 0 0 .708 0l3.5-3.5a.5.5 0 0 0-.708-.708L8.5 9.293V1.5z" />
                                </svg>
                            </span>
                        </button>

            <button type="button" class="btn btn-light-danger btn-sm" v-on:click="deleteEvent(index,val.inv_id)">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
  <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z"></path>
  <path fill-rule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z"></path>
</svg>
              
              </button>

    </td>
    </tr>
</div>
</tbody>
</table>
`
})



var vm= new Vue({
    el: '#chartpanel',
    data: {

        Approval_number: '',
        service_code: '',
        member_code: '',
        service_date: '',
        med_item: '',
        insurance_med_item:'',
        qty: 1,
        value: '',
        co_payment: '',
        local_dis: '',
        import_dis: '',
        total_med_dis: '',
        total_bvar: '',
        Rev_dis: '',
        net: '',
        num: '',
        note: '',
        member_name: '',
        value: '',
        label: '',
        icon: '',
        srv: [],
        search: '',
        last_update_by: '',
        MedI_name: '',
       
        isedit: true,
        medI: [],
       
        //lastv: this.member_code,
        labels: getall(this.batch_id),
     //   nextBarId: this.labels.length,
        contract_service_name: '',
        options: []
     

    },

    methods: {
        addRow: function (event) {
            lastId = this.labels.length;
            var newRow = {

                serial: this.lastId++,
                Approval_number: this.Approval_number,
                service_code: this.service_code,
                member_code: this.member_code,
                service_date: this.service_date,
                med_item: this.med_item,
                insurance_med_item: this.insurance_med_item,
                last_update_by: this.last_update_by,
                value: this.value,
                MedI_name: this.MedI_name,
                co_payment: this.co_payment,
                local_dis: this.local_dis,
                import_dis: this.import_dis,
                total_med_dis: this.total_med_dis,
                total_bvar: this.total_bvar,
                Rev_dis: this.Rev_dis,
                net: this.net,
                num: this.num,
                note: this.note,
                medI: this.medI,
                member_name: this.member_name,
                srv: this.srv,
                contract_service_name: this.contract_service_name,
                //lert($('#ubatch_id').val()),
               
                batch_id: document.getElementById('ubatch_id').value,
              
            };
            console.log(this.Approval_number.toString().length);
           // alert(this.service_date +""+ rdatec);
            // Validate here
            if (this.Approval_number == "" || this.Approval_number.toString().length < 7)
            {
                $('#UAppNum').focus();
            }
            
            else if (this.service_date == "" || this.service_date > rdatec)
            {
                $('#UServD').focus();
            }
            else if (this.member_code == "")
            {
                $('#UMember').focus();
            }
            else if (this.service_code == "")
            
                $('#UService').focus();
            
            else if (this.med_item == "")
            {
                $('#UMeditem').focus();
            }
            //else if (this.insurance_med_item == "")
            //{
            //    $('#UIMeditem').focus();
            //}
            else if (this.value == "")
            {
                $('#Uvalue').focus();
            }
            else if (this.co_payment == "")
            {
                $('#UCo_payment').focus();
            }
            else if (this.local_dis == "") {
                $('#Loc_dis').focus();
            }
            //else if (this.import_dis == "") {
            //    $('#imp_dis').focus();
            //}
            //else if (this.total_bvar == "") {
            //    $('#totalbc').focus();
            //}
            //else if (this.Rev_dis == "") {
            //    $('#Rev_dis').focus();
            //}
            else if (this.num == "") {
                $('#num').focus();
            }
           
            else {
                //If Valid
                let ss = saveInvoice(newRow);
                if (ss.status) {
                    newRow.inv_id = ss.inv_id;
                    newRow.serial = ss.serial;
                    this.labels.push(newRow);
                    this.clearRows();
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

                    $('#UAppNum').focus();
                    setTimeout(function () {
                       
                    }, 1000);
                }
                else {
                    console.log(ss)
                }
               
            }
            // Else Focus in first not invalid input

            
           
        },
        
        testM: function (mid) {
            //alert(lastv);
            if (mid != "") {
                console.log($("#UMember").val());
                console.log($("#UServD").val());
                //alert("in test m")
                
                Validat_Mem(mid, this.service_date, -1);
            }
            }, 
        testS: function (mid,index) {
            //this.last_update_by = mid;
            i = index;
            //alert("r")
            //$('#servid').val(mid).change();
            //let serv = getService(mid);
            //this.service_code = serv.nm_code
            //this.contract_service_name = serv.nm_name;
           
           // $('#UMeditem').focus();
        },
        test_addbyApp: function (mid,bid) {
            if (mid.toString().length == 11) {
                let inv = getDataByApp_Num(mid, bid);
                console.log(inv);
               
                if (inv._status != undefined && inv._status) {

                    this.member_code = inv._inv.member_code;
                    this.member_name = inv._inv.member_name;
                    this.service_date = inv._inv.service_date;
                    this.med_item = inv._inv.med_item;
                    this.MedI_name = inv._inv.medI_name;
                    this.srv = inv._inv.srv;
                    srv_vm.labels = inv._inv.srv;
                    this.service_code = inv._inv.service_code;
                    this.contract_service_name = inv._inv.contract_service_name;
                    this.num = srv_vm.labels.length;
                    this.value = srv_vm.getprice;

                    $('#UCo_payment').focus();
                }


            }
            else if (mid.toString().length < 7) {
                alert("Approval_number Must be more than 6,please check again !!.");
                    $("#UAppNum").focus();
            }
            else {
                var c = check7apprval_number(mid,-1);
                console.log(c);
                if (!c._status) { alert("this approval :" + c._msg); }
                else { $('#UServD').focus(); }
            }


            
        },
        clearRows: function () {
          
            this.Approval_number = "",
                this.service_code = "",
                this.member_code = "",
                this.service_date = "",
                this.med_item = "",
                this.insurance_med_item = "",
                this.value = "",
                this.co_payment = "",
                this.local_dis = "",
                this.import_dis = "",
                this.total_med_dis = "",
                this.total_bvar = "",
                this.Rev_dis = "",
                this.net = "",
                this.MedI_name="",
                this.num = "",
                this.note = "",
                this.contract_service_name="",
                this.member_name = "";
                this.srv = [];

        },
        movestep: function (id) {
            if (id != null) {
                switch (id) {
                    case "UServD":
                        if (this.service_date != "" && this.service_date < rdatec) {
                            $('#UMember').focus();
                        }
                        break;
                    case "UMeditem":
                        if (this.med_item != "")
                            $('#Uvalue').focus();
                        break;
                    //case "UIMeditem":
                    //   // if (this.insurance_med_item != "")
                    //    $('#Uvalue').focus();
                    //    break;
                   
                    case "Uvalue":
                        if (this.value != "")
                        $('#UCo_payment').focus();
                        break;
                    case "UCo_payment":
                        if (this.co_payment != "") {
                            $('#Loc_dis').focus();
                            
                        }
                           
                        break;
                    case "Loc_dis":
                        if (this.local_dis != "") {
                          
                            if (svendor == "true") {
                                $('#imp_dis').focus();
                            }
                            else {

                                $('#Rev_dis').focus();
                            }
                        }
                        
                        break;
                    case "imp_dis":
                        if (this.import_dis != "")
                            $('#Rev_dis').focus();
                        break;
                    case "totalbc":
                        if (this.total_bvar != "")
                            $('#Rev_dis').focus();
                        break;
                    case "Rev_dis":
                        if (this.Rev_dis != "")
                        $('#num').focus();
                        break;
                    case "num":
                        if (this.num != "")
                        $('#note').focus();
                        break;
                    case "note":
                        $('#Nbatch-details').focus();
                        break;

                };
            };
           
        },
        backstep: function (id) {
            if (id != null) {
                switch (id) {
                    case "UServD":
                        $('#UAppNum').focus();
                        break;
                    
                    case "UService":
                        $('#UMember').focus();
                        break;
                    case "UMember":
                        $('#UServD').focus();
                        break;
                    case "UMeditem":
                        $('#UService').focus();
                        break;
                    case "UIMeditem":
                        $('#UMeditem').focus();
                        break;
                    case "Uvalue":
                        $('#UMeditem').focus();
                        break;
                    case "UCo_payment":
                        $('#Uvalue').focus();
                        break;
                    case "Loc_dis":
                        $('#UCo_payment').focus();
                        break;
                    case "imp_dis":
                        $('#Loc_dis').focus();
                        break;
                    case "Rev_dis":
                        if (svendor == "true") {
                            $('#imp_dis').focus();
                        }
                        else {

                            $('#Loc_dis').focus();
                        }
                       
                        break;
                    //case "Rev_dis":
                    //    $('#totalbc').focus();
                    //    break;
                    case "num":
                        $('#Rev_dis').focus();
                        break;
                    case "note":
                        $('#num').focus();
                        break;

                };
            };

        },
        addTag(newTag) {
            const tag = {
                name: newTag,
                code: newTag.substring(0, 2) + Math.floor((Math.random() * 10000000))
            }
            this.options.push(tag)
            this.value.push(tag)
        }
    },
    computed: {
        filteredItems() {
            return this.labels.filter(item => {
                return item.member_name.toLowerCase().indexOf(this.search.toLowerCase()) > -1
            })
        },
        totalcost: function () {

            let total = 0;
            this.filteredItems.forEach(function (val) {
                total += (+val.value);
            });

            return total;
        },
        totalcopay: function () {

            let total = 0;
            this.filteredItems.forEach(function (val) {
                total += (+val.co_payment);
            });

            return total;
        },
        totalcondis: function () {

            let total = 0;
            this.filteredItems.forEach(function (val) {
                total += (+val.local_dis);
            });

            return total;
        },
        totalrevdis: function () {

            let total = 0;
            this.filteredItems.forEach(function (val) {
                total += (+val.Rev_dis);
            });

            return total;
        },
        totaldis: function () {

            let total = 0;
            this.filteredItems.forEach(function (val) {
                total += (+val.local_dis) + (+val.co_payment);
            });

            return total;
        },

        totalnet: function () {

            let total = 0;
            this.filteredItems.forEach(function (val) {
                let _n = ((+val.value) - (+val.co_payment) - (+val.local_dis) - (+val.import_dis) - (+val.Rev_dis));
                total += _n;
            });
            return total;
        },
        getnet: function () {

            let total = 0;
            let _n = ((+this.value) - (+this.co_payment) - (+this.local_dis) - (+this.Rev_dis));
            total = _n;
            return total;
        },
        getdis: function () {

            let total = 0;
            total = (+this.local_dis) + (+this.co_payment) + (+this.import_dis);
            return total;
        },
        //gettotalprice: function () {

        //    let total = 0;
        //    total = this.proplabels[index].srv.forEach(function (i) {
        //        total += (+i.price);
        //        console.log(this)
        //    });
        //        return total;
        //    },
        
       
        
   },
});

//function testM() { alert('Ok') }

function saveInvoice(_element) {
    var sta = { status: false, serial: "" };
    //  this.proplabels.splice(index, 1);
   // let serv = $('#servid').val().toString();
    //alert(serv.toString());
   // console.log($('#servid').val());
    let myData = { batch: _element, servs: _element.srv }
    console.log(myData);
    //_element.last_update_by = serv;//$('#servid').val()[2];
    $.ajax({
        url: "/Batches/saveInv",
        type: "POST",
        dataType: "json",
        async: false,
        cashe: false,
        data: myData,
        success: function (res) {
            console.log(res);
            //_element.serial = res.serial;
            if (res.status == true) {
                sta.status = res.status;
                sta.serial = res.serial;
                sta.inv_id = res.inv_id
            }
            else {
               
                Swal.fire({
                    title: 'Oops...',
                    text: "there is some thing error,please check code !!",
                    icon: 'error',
                    confirmButtonColor: '#3085d6',
                    confirmButtonText: 'OK !'
                }).then((result) => {
                    $('#UMember').focus()
                })
            }
           
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("jqXHR : " + jqXHR + " text status : " + textStatus + " error : " + errorThrown);
            alert("jqXHR : " + jqXHR + " text status : " + textStatus + " error : " + errorThrown);
        }

    });
    //setTimeout(function () { return sta; }, 500);
    return sta;
}

function editInvoice(o) {
    let editData = { batch: o, servs: o.srv }
    $.ajax({
        url: "/Batches/editInv",
        type: "POST",
        dataType: "json",
        cashe: false,
        data: editData,
        success: function (res) {
            console.log(res.status);
            if (res.status == true) {
                return res.status;
                
            }
            else {
               
                Swal.fire({
                    title: 'Oops...',
                    text: "there is some thing error,please check code !!",
                    icon: 'error',
                    confirmButtonColor: '#3085d6',
                    confirmButtonText: 'OK !'
                }).then((result) => {
                    
                })
            }
           
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("jqXHR : " + jqXHR + " text status : " + textStatus + " error : " + errorThrown);
            alert("jqXHR : " + jqXHR + " text status : " + textStatus + " error : " + errorThrown);
        }
    });
}

function getMember(mid) {

    var nm = '';
    $.ajax({
        url: "/Batches/getMemberByID?id=" + mid,
        type: "get",
        dataType: "json",
        async: false,
        cashe: false,
       // data: { id: mid },
        success: function (res) {
            // alert(res.msg)
            //console.log(res);
            nm = res.msg;
           
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("jqXHR : " + jqXHR + " text status : " + textStatus + " error : " + errorThrown);
            alert("jqXHR : " + jqXHR + " text status : " + textStatus + " error : " + errorThrown);
        }
    });
    return nm;
}

function getService(mid) {

    var nm = { nm_code: 0, nm_name:"" };
   
    $.ajax({
        url: "/Batches/getServiceByID?id=" + mid,
        type: "get",
        dataType: "json",
       async: false,
        cashe: false,
       // data: { id: mid },
        success: function (res) {
             //alert(res.msg)
            //console.log(res);
            nm.nm_code = res.msg_code;
            nm.nm_name = res.msg_name;
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("jqXHR : " + jqXHR + " text status : " + textStatus + " error : " + errorThrown);
            alert("jqXHR : " + jqXHR + " text status : " + textStatus + " error : " + errorThrown);
        }
    });
    return nm;
}


function getDataByApp_Num(mid,bid) {

    var nm;
   // alert(bid);
    var data = { id: mid, batchid: bid };
    $.ajax({
        url: "/Batches/getDataByApp_Num",
        type: "get",
        dataType: "json",
        async: false,
        cashe: false,
        data: data,
        success: function (res) {
            // alert(res.msg)
            //console.log(res);
            if (res._msg == "Repeated")
            {
                alert("Approval Number is Repeated,please check Batch id = " + res._inv);
            }
            if (res._msg == "approval not Finished") {
                alert("Approval Number not Finished");
            }

            nm = res;//._inv;
          
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("hi");
            console.log("jqXHR : " + jqXHR + " text status : " + textStatus + " error : " + errorThrown);
            alert("jqXHR : " + jqXHR + " text status : " + textStatus + " error : " + errorThrown);
        }
    });
    return nm;

}

function check7apprval_number(id, x) {
    let batchVen_id = vendorbatch;
    var batch_id = document.getElementById('ubatch_id').value;
   // alert(batchVen_id + "====" + batch_id + "===="+id +x);
    var datacheck7 = { id: id, batch: batch_id, vid: batchVen_id, inv_id: x };
    var nm;
    $.ajax({
        url: "/Batches/check7apprval_number",
        type: "get",
        dataType: "json",
        async: false,
        cashe: false,
        data: datacheck7,
        success: function (res) {
            // alert(res.msg)
            //console.log(res);
            nm = res;

        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("jqXHR : " + jqXHR + " text status : " + textStatus + " error : " + errorThrown);
            alert("jqXHR : " + jqXHR + " text status : " + textStatus + " error : " + errorThrown);
        }
    });
    return nm;
}

function getselectedservs(id) {
    var nm;
    //alert(vendorbatch);
    $.ajax({
        url: "/Batches/getServs",
        type: "get",
        dataType: "json",
        async: false,
        cashe: false,
        data: { id: id, type: vendorbatch },
        success: function (res) {
            // alert(res.msg)
            //console.log(res);
            nm = res;

        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("jqXHR : " + jqXHR + " text status : " + textStatus + " error : " + errorThrown);
            alert("jqXHR : " + jqXHR + " text status : " + textStatus + " error : " + errorThrown);
        }
    });
    return nm;
}

function getall(id) {
   
    var nm;
    $.ajax({
        url: "/Batches/getInv?id=" + id,
        type: "get",
        dataType: "json",
        async: false,
        cashe: false,
       //data: { ser: mid , id:id },
        success: function (res) {
            // alert(res.msg)
            //console.log(res);

            res.forEach(item => { item.medI = []; item.srv = []; })

            nm = res;

        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("jqXHR : " + jqXHR + " text status : " + textStatus + " error : " + errorThrown);
            alert("jqXHR : " + jqXHR + " text status : " + textStatus + " error : " + errorThrown);
        }
    });
    return nm;

}
