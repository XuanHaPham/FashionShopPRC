<template>
    <div :class="[ openModal ? 'is-active' : '', 'modal' ]">
      <div class="modal-background"></div>
      <div class="modal-card">
        <header class="modal-card-head">
          <p v-if="!isUserSignedUp" class="modal-card-title">{{ modalTitle }}</p>
          <p v-if="isUserSignedUp" class="modal-card-title">{{ modalTitleRegistered }}</p>
          <button class="delete" aria-label="close" @click="closeModal"></button>
        </header>
        <form @submit="checkForm" action="#" method="post">
          <section class="modal-card-body">
            <div v-if="!isUserSignedUp">
              <div class="field">
                <p class="control has-icons-left has-icons-right">
                  <input
                    :class="[highlightFullNameWithError ? 'input is-danger' : 'input']"
                    type="text"
                    :placeholder="fullnamePlaceholder"
                    v-model="fullname"
                    
                    @keyup="checkFullNameOnKeyUp(fullname)"
                  >
                  <span class="icon is-small is-left">
                    <i class="fa fa-user-circle"></i>
                  </span>
                  <span v-if="highlightFullNameWithError !== null" class="icon is-small is-right">
                    <i :class="[highlightFullNameWithError ? 'fa fa-exclamation-circle' : 'fa fa-check']"></i>
                  </span>
                </p>
                <p v-if="highlightFullNameWithError" class="help is-danger">{{ fullnameErrorLabel }}</p>
                
              </div>
              

              <div class="field">
                <p class="control has-icons-left has-icons-right">
                  <input
                    :class="[highlightDOBWithError ? 'input is-danger' : 'input']"
                    type="date"
                    :placeholder="DOBPlaceholder"
                    v-model="DOB"
                    @keyup="checkDOBOnKeyUp(DOB)"
                  >
                  <span class="icon is-small is-left">
                  <i class="fa fa-birthday-cake"></i>
                  </span>
                  <span v-if="highlightDOBWithError !== null" class="icon is-small is-right">
                    <i :class="[highlightDOBWithError ? 'fa fa-exclamation-circle' : 'fa fa-check']"></i>
                  </span>
                </p>
                <p v-if="highlightDOBWithError" class="help is-danger">{{ DOBErrorLabel }}</p>
               
              </div>
                <div class="field">
                <p class="control has-icons-left has-icons-right">
                  <input
                    :class="[highlightPhoneWithError ? 'input is-danger ' : 'input']"
                    type="text"
                    :placeholder="phonePlaceholder"
                    v-model="phone"
                    @keyup="checkPhoneOnKeyUp(phone)"
                  >
                  <span class="icon is-small is-left">
                    <i class="fa fa-phone"></i>
                  </span>
                  <span v-if="highlightPhoneWithError !== null" class="icon is-small is-right">
                    <i :class="[highlightPhoneWithError ? 'fa fa-exclamation-circle' : 'fa fa-check']"></i>
                  </span>
                </p>
                <p v-if="highlightPhoneWithError" class="help is-danger">{{ phoneErrorLabel }}</p>
                
              </div>  


              <br/>
            <div class="field">
                <p class="control has-icons-left has-icons-right">
                  <input
                    :class="[highlightAddressWithError ? 'input is-danger ' : 'input']"
                    type="text"
                    :placeholder="addressPlaceholder"
                    v-model="address"
                    @keyup="checkAddressOnKeyUp(address)"
                  >
                  <span class="icon is-small is-left">
                    <i class="fa fa-map"></i>
                  </span>
                  <span v-if="highlightAddressWithError !== null" class="icon is-small is-right">
                    <i :class="[highlightAddressWithError ? 'fa fa-exclamation-circle' : 'fa fa-check']"></i>
                  </span>
                </p>
                <p v-if="highlightAddressWithError" class="help is-danger">{{ addressErrorLabel }}</p>
                
              </div>  

              <div class="field">
                <p class="control has-icons-left has-icons-right">
                  <input
                    :class="[highlightAddress1WithError ? 'input is-danger ' : 'input']"
                    type="text"
                    :placeholder="address1Placeholder"
                    v-model="address1"
                    @keyup="checkAddress1OnKeyUp(address1)"
                  >
                  <span class="icon is-small is-left">
                    <i class="fa fa-map"></i>
                  </span>
                  <span v-if="highlightAddress1WithError !== null" class="icon is-small is-right">
                    <i :class="[highlightAddress1WithError ? 'fa fa-exclamation-circle' : 'fa fa-check']"></i>
                  </span>
                </p>
                <p v-if="highlightAddress1WithError" class="help is-danger">{{ addressErrorLabel }}</p>
                
              </div> 
              
              <br/>
              <div class="field">
                <p class="control has-icons-left has-icons-right">
                  <input
                    :class="[highlightNameWithError ? 'input is-danger' : 'input']"
                    type="text"
                    :placeholder="namePlaceholder"
                    v-model="name"
                    @keyup="checkNameOnKeyUp(name)"
                  >
                  <span class="icon is-small is-left">
                    <i class="fa fa-user"></i>
                  </span>
                  <span v-if="highlightNameWithError !== null" class="icon is-small is-right">
                    <i :class="[highlightNameWithError ? 'fa fa-exclamation-circle' : 'fa fa-check']"></i>
                  </span>
                </p>
                <p v-if="highlightNameWithError" class="help is-danger">{{ nameErrorLabel }}</p>
              </div>

              <div class="field">
                <p class="control has-icons-left has-icons-right">
                  <input
                    :class="[highlightEmailWithError ? 'input is-danger' : 'input']"
                    type="email"
                    :placeholder="emailPlaceholder"
                    name="emailName"
                    v-model="email"
                    @keyup="checkEmailOnKeyUp(email)"
                  >
                  <span class="icon is-small is-left">
                    <i class="fa fa-envelope"></i>
                  </span>
                  <span v-if="highlightEmailWithError !== null" class="icon is-small is-right">
                    <i :class="[highlightEmailWithError ? 'fa fa-exclamation-circle' : 'fa fa-check']"></i>
                  </span>
                </p>
                <p v-if="highlightEmailWithError" class="help is-danger">{{ emailErrorLabel }}</p>
              </div>

              <div class="field">
                <p class="control has-icons-left has-icons-right">
                  <input
                    :class="[highlightPasswordWithError ? 'input is-danger' : 'input']"
                    type="password"
                    :placeholder="passwordPlaceholder"
                    v-model="password"
                    @keyup="checkPasswordOnKeyUp(password)"
                  >
                  <span class="icon is-small is-left">
                    <i class="fa fa-lock"></i>
                  </span>
                  <span v-if="highlightPasswordWithError !== null" class="icon is-small is-right">
                    <i :class="[highlightPasswordWithError ? 'fa fa-exclamation-circle' : 'fa fa-check']"></i>
                  </span>
                </p>
                <p v-if="highlightPasswordWithError" class="help is-danger">{{ passwordErrorLabel }}</p>
              </div>
              <div class="field">
                <p class="control has-icons-left has-icons-right">
                  <input
                    :class="[highlightRepeatPasswordWithError ? 'input is-danger' : 'input']"
                    type="password"
                    :placeholder="repeatPasswordPlaceholder"
                    v-model="repeatPassword"
                    @keyup="checkRepeatPasswordOnKeyUp(repeatPassword)"
                  >
                  <span class="icon is-small is-left">
                    <i class="fa fa-lock"></i>
                  </span>
                  <span v-if="highlightRepeatPasswordWithError !== null" class="icon is-small is-right">
                    <i :class="[highlightRepeatPasswordWithError ? 'fa fa-exclamation-circle' : 'fa fa-check']"></i>
                  </span>
                </p>
                <p v-if="highlightRepeatPasswordWithError" class="help is-danger">{{ notEqualErrorLabel }}</p>
              </div>
              
              
            </div>
            <div v-if="isUserSignedUp" class="level">
              <div class="level-item has-text-centered">
                <div>
                  <p class="title">Welcome {{ name }}!</p>
                  <p class="heading">Now you are a member</p>
                </div>
              </div>
            </div>
          </section>
          <footer class="modal-card-foot">
            <button v-if="!isUserSignedUp" class="button is-success">{{ primaryBtnLabel }}</button>
            <button v-if="isUserSignedUp" type="button" class="button is-info" @click="closeModal">{{ btnRegisteredLabel }}</button>
          </footer>
        </form>
      </div>
    </div>
</template>

<script>
import { isValidEmail } from '@/assets/validators';
import axios from 'axios';
import { base, openapi, methods, routes, setToken, requestToken, register } from '@/store/index.js'
// export const users = {
//     address,
//   dob: '',
//   email: '',
//   fullName: '',
//   password: '',
//   phoneNumber: 0,
//   shippingAddress: '',
//   username: ''
// };
export default {

  name: 'registration',

  data () {
    return {
      modalTitle: 'Sign up',
      modalTitleRegistered: 'Welcome ',
      primaryBtnLabel: 'Sign up',
      btnRegisteredLabel: 'Close',
      fullnamePlaceholder: 'FullName*',
      namePlaceholder: 'UserName*',
      emailPlaceholder: 'Email*',
      addressPlaceholder:'Address shipping 1*',
      address1Placeholder:'Address shipping 2*',
      passwordPlaceholder: 'Password*',
      repeatPasswordPlaceholder: 'Repeat Password*',
      DOBPlaceholder:"Birthday*",
      phonePlaceholder:"Phone Number",
      notEqualErrorLabel: 'Passwords must be equal',
      passwordErrorLabel: 'Password required',
      nameErrorLabel: 'Username required',
      fullnameErrorLabel: 'Full Name required',
      addressErrorLabel: 'Address required',
      phoneErrorLabel: 'Phone required',
      emailErrorLabel: 'Email required',
      DOBErrorLabel: 'Date of birth required',
      emailNotValidLabel: 'Valid email required',
      name: '',
      email: '',
      password: '',
      repeatPassword: '',
      address:'',
      address1:'',
      fullname:'',
      DOB:'',
      phone:'',
      current:'',
      highlightFullNameWithError: null,
      highlightNameWithError: null,
      highlightDOBWithError: null,
      highlightAddressWithError: null,
      highlightAddress1WithError: null,
      highlightPhoneWithError: null,
      highlightEmailWithError: null,
      highlightPasswordWithError: null,
      highlightRepeatPasswordWithError: null,
      isFormSuccess: false
    };
  },
  

  computed: {
    isUserSignedUp () {
      return this.$store.getters.isUserSignedUp;
    },
    openModal () {
      if (this.$store.getters.isSignupModalOpen) {
        return true;
      } else {
        return false;
      }
    }
  },

  methods: {
    closeModal () {
      this.$store.commit('showSignupModal', false);
    },
    checkForm (e) {
      e.preventDefault();

      if (this.DOB && this.fullname && this.phone && this.address && this.address1 && this.name && this.email && this.password && this.repeatPassword) {
        this.highlightEmailWithError = false;
        this.highlightPasswordWithError = false;
        this.highlightRepeatPasswordWithError= false;
        this.highlightNameWithError= false;
        this.highlightFullNameWithError= false;
        this.highlightDOBWithError=false;
        this.highlightAddressWithError=false;
        this.highlightAddress1WithError= false;
        this.highlightPhoneWithError=false;
        
    //     this.users.username= this.name;
    //     this.users.password=this.password;
    //     this.users.email=this.email;
    //     this.users.phoneNumber= this.phone;
    //   this.users.address= this.address;
    //  this.users.fullName= this.fullName;
    //  this.users.dob=this.DOB;
    //  this.users.shippingAddress=this.address1;

      const dataToSend = {
        "address": this.address,
      "dob": this.DOB,
      "email": this.email,
       "fullName": this.fullname,
      "password": this.repeatPassword,
       "phoneNumber": this.phone,
       "shippingAddress": this.address1,
  "username": this.name
        };
      //   this.modalTitlemoemodgimstered=dataToSend.phone;
      //   axios.post('http://localhost:8080/accounts',{
      //     "address": this.address,
      //     "dob": this.DOB,
      //     "email": this.email,
      //     "fullName": this.fullname,
      //     "password": this.repeatPassword,
      //   "phoneNumber": this.phone,
      //   "shippingAddress": this.address1,
      // "username": this.name
      //   }).then(response => {
      // if(response.data.ID !=null){

      //   this.isFormSuccess = true;
          
      //   this.$store.commit('setUserName', data.username);
      //   this.$store.commit('isUserSignedUp', this.isFormSuccess);
      //   this.$store.commit('isUserLoggedIn', this.isFormSuccess);
      //   }
      //   }).catch(error => console.log(error));
        openapi(methods.POST, routes.ACCOUNT, {
        "address": this.address,
      "dob": this.DOB,
      "email": this.email,
       "fullName": this.fullname,
        "password": this.repeatPassword,
       "phoneNumber": this.phone,
       "shippingAddress": this.address1,
        "username": this.name,
        "status": true
        }).then(data => {
        this.detailMessage = 'Added successfully!'; 
        // this.items.push(data);
        this.current = data;
        if(data !=null){

        this.isFormSuccess = true;
          
        this.$store.commit('setUserName', data.username);
        this.$store.commit('setEmail', data.email);
          this.$store.commit('setPhoneNumber', data.phoneNumber);
          this.$store.commit('setAddress', data.address);
          this.$store.commit('setAddress1', data.shippingAddress);
          this.$store.commit('setDOB', data.dob);
          this.$store.commit('setFullName', data.fullName);
          this.$store.commit('setID', data.id);
          this.$store.commit('setPassword', this.password);
        this.$store.commit('isUserSignedUp', this.isFormSuccess);
        this.$store.commit('isUserLoggedIn', this.isFormSuccess);
        }
        }
    );
    // let dataRecieved=""; 
    // fetch("http://localhost:8080/accounts",{credentials:'same-origin',mode:'same-origin',method:"post",body:JSON.stringify(dataToSend)})
    //           .then(resp => {
    //             if(resp.status==200){
    //                return resp.json()
    //             }else{
    //                 console.log("Status: "+resp.status);
    //                 return Promise.reject("server")
    //             }
    //           })
    //        .then(dataJson =>{
    //              dataToRecieved = JSON.parse(dataJson);
    //          })
    //           .catch(err =>{
    //             if(err=="server")return
    //             console.log(err);
    //         })
            

        // this.isFormSuccess = true;
        // this.$store.commit('setUserName', this.name);
        // this.$store.commit('isUserSignedUp', this.isFormSuccess);
        // this.$store.commit('isUserLoggedIn', this.isFormSuccess);

        //   this.$store.commit('setEmail', this.email);
        //   this.$store.commit('setPhoneNumber', this.phone);
        //   this.$store.commit('setAddress', this.address);
        //   this.$store.commit('setAddress1', this.address1);
        //   this.$store.commit('setDOB', this.DOB);
        //   this.$store.commit('setFullName', this.fullname);
      }

      if (!this.fullname) {
        this.highlightFullNameWithError = true;
      } else {
        this.highlightFullNameWithError = false;
      }

      if (!this.DOB) {
        this.highlightDOBWithError = true;
      } else {
        this.highlightDOBWithError = false;
      }

      if (!this.phone) {
        this.highlightPhoneWithError = true;
      } else {
        this.highlightPhoneWithError = false;
      }

      if (!this.address) {
        this.highlightAddressWithError = true;
      } else {
        this.highlightAddressWithError = false;
      }
      
      if (!this.address1) {
        this.highlightAddress1WithError = true;
      } else {
        this.highlightAddress1WithError = false;
      }

      if (!this.name) {
        this.highlightNameWithError = true;
      } else {
        this.highlightNameWithError = false;
      }

      if (!this.email) {
        this.highlightEmailWithError = true;

        if (this.email && !isValidEmail(this.email)) {
          this.emailErrorLabel = this.emailNotValidLabel;
        }
      } else {
        this.highlightEmailWithError = false;
      }

      if (!this.password) {
        this.highlightPasswordWithError = true;
      } else {
        this.highlightPasswordWithError = false;
      }

      if (!this.repeatPassword) {
        this.highlightRepeatPasswordWithError = true;
      } else {
        this.highlightRepeatPasswordWithError = false;
      }
    },
    checkFullNameOnKeyUp (fullnameValue) {
      if (fullnameValue) {
        this.highlightFullNameWithError = false;
      } else {
        this.highlightFullNameWithError = true;
      }
    },

    checkAddressOnKeyUp (addressValue) {
      if (addressValue) {
        this.highlightAddressWithError = false;
      } else {
        this.highlightAddressWithError = true;
      }
    },

    checkAddress1OnKeyUp (address1Value) {
      if (address1Value) {
        this.highlightAddress1WithError = false;
      } else {
        this.highlightAddress1WithError = true;
      }
    },

    checkDOBOnKeyUp (DOBValue) {
      if (DOBValue) {
        this.highlightDOBWithError = false;
      } else {
        this.highlightDOBWithError = true;
      }
    },

    checkNameOnKeyUp (nameValue) {
      if (nameValue) {
        this.highlightNameWithError = false;
      } else {
        this.highlightNameWithError = true;
      }
    },

    checkPhoneOnKeyUp (phoneValue) {
      if (phoneValue) {
        this.highlightPhoneWithError = false;
      } else {
        this.highlightPhoneWithError = true;
      }
    },

    checkEmailOnKeyUp (emailValue) {
      if (emailValue && isValidEmail(emailValue)) {
        this.highlightEmailWithError = false;
      } else {
        this.highlightEmailWithError = true;

        if (!isValidEmail (emailValue)) {
          this.emailErrorLabel = this.emailNotValidLabel;
        }
      }
    },
    checkPasswordOnKeyUp (passwordValue) {
      if (passwordValue) {
        this.highlightPasswordWithError = false;

        if (this.repeatPassword === this.password) {
          this.highlightRepeatPasswordWithError = false;
        } else {
          this.highlightRepeatPasswordWithError = true;
        }
      } else {
        this.highlightPasswordWithError = true;
      }
    },
    checkRepeatPasswordOnKeyUp (repeatPasswordValue) {
      if (repeatPasswordValue) {
        if (repeatPasswordValue === this.password) {
          this.highlightRepeatPasswordWithError = false;
        } else {
          this.highlightRepeatPasswordWithError = true;
        }
      } else {
        this.highlightRepeatPasswordWithError = true;
      }
    }
  }
};
</script>

<style lang="scss" scoped>
.fa-exclamation-circle {
  color: red;
}
.fa-check {
  color: green;
}
</style>


