<template>
    <div :class="[ openModal ? 'is-active' : '', 'modal' ]">
      <div class="modal-background"></div>
      <div class="modal-card">
        <header class="modal-card-head">
          <p v-if="!isUserPassword" class="modal-card-title">{{ modalTitle }}</p>
          <p v-if="isUserPassword" class="modal-card-title">{{ modalTitleRegistered }}</p>
          <button class="delete" aria-label="close" @click="closeModal"></button>
        </header>
        <form @submit="checkForm" action="#" method="post">
          <section class="modal-card-body">
            <div v-if="!isUserPassword">
              <div class="field">
                <p class="control has-icons-left has-icons-right">
                  <input
                    :class="[highlightOldPasswordWithError ? 'input is-danger' : 'input']"
                    type="password"
                    :placeholder="oldpasswordPlaceholder"
                    v-model="oldpassword"
                  >
                  <span class="icon is-small is-left">
                    <i class="fa fa-lock"></i>
                  </span>
                  <span v-if="highlightOldPasswordWithError !== null" class="icon is-small is-right">
                    <i :class="[highlightOldPasswordWithError ? 'fa fa-exclamation-circle' : 'fa fa-check']"></i>
                  </span>
                </p>
                <p v-if="highlightOldPasswordWithError" class="help is-danger">{{ oldpasswordErrorLabel }}</p>
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
            <div v-if="isUserPassword" class="level">
              <div class="level-item has-text-centered">
                <div>
                  <p class="title">Change Password Sucessful</p>
                </div>
              </div>
            </div>
          </section>
          <footer class="modal-card-foot">
            <button v-if="!isUserPassword" class="button is-success">{{ primaryBtnLabel }}</button>
            <button v-if="isUserPassword" type="button" class="button is-info " @click="closeModal">{{ btnRegisteredLabel }}</button>
          </footer>
        </form>
      </div>
    </div>
</template>

<script>
import { isValidEmail } from '@/assets/validators';
import { base, openapi, methods, routes, setToken, requestToken } from '@/store/index.js'

export default {
  name: 'registration',

  data () {
    return {
      modalTitle: 'Change Password',
      modalTitleRegistered: 'Change Password ',
      primaryBtnLabel: 'Change Password',
      btnRegisteredLabel: 'Close',
      fullnamePlaceholder: 'FullName*',
      namePlaceholder: 'UserName*',
      emailPlaceholder: 'Email*',
      addressPlaceholder:'Address shipping 1*',
      address1Placeholder:'Address shipping 2*',
      oldpasswordPlaceholder: 'OldPassword*',
      passwordPlaceholder: 'Password*',
      repeatPasswordPlaceholder: 'Repeat Password*',
      DOBPlaceholder:"Birthday*",
      phonePlaceholder:"Phone Number",
      oldpasswordErrorLabel:"Wrong Password",
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
      oldpassword: '',
      password: '',
      repeatPassword: '',
      address:'',
      address1:'',
      fullname:'',
      DOB:'',
      phone:'',
      highlightFullNameWithError: null,
      highlightNameWithError: null,
      highlightDOBWithError: null,
      highlightAddressWithError: null,
      highlightAddress1WithError: null,
      highlightPhoneWithError: null,
      highlightEmailWithError: null,
      highlightPasswordWithError: null,
      highlightOldPasswordWithError: null,
      highlightRepeatPasswordWithError: null,
      isFormSuccess: false
    };
  },

  computed: {
    isUserPassword () {
      return this.$store.getters.isUserPassword;
    },
    getPassword () {
			let name = this.$store.getters.getPassword;
			
			if (name === '') {
				return 'user';
			} else {
				return name;
			}
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
      if (this.$store.getters.isPasswordModalOpen) {
        return true;
      } else {
        return false;
      }
    }
  },

  methods: {
    closeModal () {
      this.$store.commit('isUserPassword', false);
      this.$store.commit('showPasswordModal', false);
      this.isFormSuccess = false;
      
      this.modalTitle= 'Change Password';
    },
    checkForm (e) {
      e.preventDefault();

      if (this.oldpassword && this.password && this.repeatPassword) {
        
        this.highlightPasswordWithError = false;
        this.highlightOldPasswordWithError = false;
        this.highlightRepeatPasswordWithError = false;
        this.isFormSuccess = true;

      if(this.oldpassword == this.getPassword){
      openapi(methods.POST, routes.PASSWORD, {
        "password": this.repeatPassword,
        "id": this.getID
        }).then(data => {
        if(data.id !=null){
          
          this.$store.commit('isUserPassword', this.isFormSuccess);
          this.$store.commit('setPassword', this.password);
        }
        else this.modalTitle="Change Password Fail";
        });
      }
      else this.highlightOldPasswordWithError= true;



        // this.$store.commit('setUserName', this.name);
        // this.$store.commit('isUserLoggedIn', this.isFormSuccess);
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
    checkOldPasswordOnKeyUp (oldpasswordValue) {
      if (oldpasswordValue) {
        this.highlightPasswordWithError = false;

        // if (this.repeatPassword === this.password) {
        //   this.highlightRepeatPasswordWithError = false;
        // } else {
        //   this.highlightRepeatPasswordWithError = true;
        // }
      } else {
        this.highlightPasswordWithError = true;
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


