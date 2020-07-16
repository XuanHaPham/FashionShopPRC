<template>
    <div :class="[ openModal ? 'is-active' : '', 'modal' ]">
      <div class="modal-background"></div>
      <div class="modal-card">
        <header class="modal-card-head">
          <p v-if="!isUserUpdate" class="modal-card-title">{{ modalTitle }}</p>
          <p v-if="isUserUpdate" class="modal-card-title">{{ modalTitleRegistered }}</p>
          <button class="delete" aria-label="close" @click="closeModal"></button>
        </header>
        <form @submit="checkForm" action="#" method="post">
          <section class="modal-card-body">
            <div v-if="!isUserUpdate">
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

              
              
            </div>
            <div v-if="isUserUpdate" class="level">
              <div class="level-item has-text-centered">
                <div>
                  <p class="title">{{ notiLable }}</p>
                </div>
              </div>
            </div>
          </section>
          <footer class="modal-card-foot">
            <button v-if="!isUserUpdate"  class="button is-success">{{ primaryBtnLabel }}</button>
            <button v-if="isUserUpdate" type="button" class="button is-info" @click="closeModal">{{ btnRegisteredLabel }}</button>
          </footer>
        </form>
      </div>
    </div>
</template>

<script>
import { isValidEmail } from '@/assets/validators';

import { base, openapi, methods, routes, setToken, requestToken, register } from '@/store/index.js'
export default {
  name: 'registration',

  data () {
    return {
      notiLable:'Update Successful',
      modalTitle: 'Update Profile',
      modalTitleRegistered: 'Update ',
      primaryBtnLabel: 'Update',
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
      //  name: $store.getters.getUserName,
      // email: $store.getters.getEmail,
      // address:$store.getters.getAddress,
      // address1:$store.getters.getAddress1,
      // fullname:$store.getters.getFullName,
      // DOB:$store.getters.getDOB,
      // phone:$store.getters.getPhoneNumber,
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
    isUserUpdate () {
      return this.$store.getters.isUserUpdate;
    },

    getID () {
			let name = this.$store.getters.getID;
			
			if (name === '') {
				return 'user';
			} else {
				return name;
			}
    },
    openModal () {
      if (this.$store.getters.isUpdateModalOpen) {
        return true;
      } else {
        return false;
      }
    }
  },

  methods: {
    closeModal () {
      this.$store.commit('isUserUpdate', false);
	  this.$store.commit('showUpdateModal', false);
    this.isFormSuccess = false;
    this.notiLable='Update Successful';
    },
    checkForm (e) {
      e.preventDefault();

      if (this.DOB && this.fullname && this.phone && this.address && this.address1 ) {
       
        this.highlightFullNameWithError= false;
        this.highlightDOBWithError=false;
        this.highlightAddressWithError=false;
        this.highlightAddress1WithError= false;
        this.highlightPhoneWithError=false;

        openapi(methods.PUT, routes.ACCOUNT, {
        "address": this.address,
        "dob": this.DOB,
        "fullName": this.fullname,
        "phoneNumber": this.phone,
        "shippingAddress": this.address1,
        "id": this.getID
        }).then(data => {
        if(data.id !=null){

        this.isFormSuccess = true;
          
          this.$store.commit('setPhoneNumber', this.phone);
          this.$store.commit('setAddress', this.address);
          this.$store.commit('setAddress1', this.address1);
          this.$store.commit('setDOB', this.DOB);
          this.$store.commit('setFullName', this.fullname);
          this.$store.commit('isUserUpdate', this.isFormSuccess);
        }
        else this.notiLable='Update Fail';
        }
        
    );
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


    checkPhoneOnKeyUp (phoneValue) {
      if (phoneValue) {
        this.highlightPhoneWithError = false;
      } else {
        this.highlightPhoneWithError = true;
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


