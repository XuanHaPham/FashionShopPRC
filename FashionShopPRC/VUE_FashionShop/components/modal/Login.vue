<template>
  <div :class="[ openModal ? 'is-active' : '', 'modal' ]">
    <div class="modal-background"></div>
    <div class="modal-card">
      <header class="modal-card-head">
          <p v-if="!isUserLoggedIn && !isUserCheckLogin" class="modal-card-title">{{ modalTitle }}</p>
          <p v-if="isUserLoggedIn" class="modal-card-title">{{ modalTitleLoggedIn }}</p>
          <p v-if="isUserCheckLogin" class="modal-card-title">{{ modalTitleCheckLogin }}</p>
          <button class="delete" aria-label="close" @click="closeModal"></button>
      </header>
      <form @submit="checkForm" action="#" method="post">
        <section class="modal-card-body">
          <div v-if="!isUserLoggedIn && !isUserCheckLogin">
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
                <p v-if="highlightEmailWithError" class="help is-danger">{{ emailRequiredLabel }}</p>
            </div>
            <div class="field">
              <p class="control has-icons-left has-icons-right">
                <input 
                  :class="[highlightPasswordWithError ? 'input is-danger' : 'input']"
                  type="password"
                  placeholder="Your password"
                  name="passwordName"
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
              <p v-if="highlightPasswordWithError" class="help is-danger">{{ passwordRequiredLabel }}</p>
            </div>
          </div>
          <div v-if="isUserLoggedIn" class="level">
            <div class="level-item has-text-centered">
              <div>
                <p class="title">Welcome back!</p>
                <p class="heading">Now you are logged in</p>
              </div>
            </div>
          </div>
          <div v-if="isUserCheckLogin" class="level">
            <div class="level-item has-text-centered">
              <div>
                <p class="title">{{ checkLabel }}</p>
                <p class="heading">Please waiting</p>
              </div>
            </div>
          </div>
        </section>
        <footer class="modal-card-foot">
          <button v-if="!isUserLoggedIn && !isUserCheckLogin" type="submit" class="button is-info">{{ primaryBtnLabel }}</button>
          <button v-if="isUserLoggedIn" type="button" class="button is-info" @click="closeModal">{{ btnLoggedInLabel }}</button>
          <!-- <button v-if="isUserCheckLogin" type="button" class="button is-info" @click="closeModal">{{ btnLoggedInLabel }}</button> -->
        </footer>
      </form>
    </div>
  </div>
</template>

<script>
import { isValidEmail } from '@/assets/validators';
import { base, openapi, methods, routes, setToken, requestToken } from '@/store/index.js'
export default {
  name: 'login',

  data () {
    return {
      modalTitle: 'Log in',
      modalTitleLoggedIn: 'Welcome!',
      modalTitleCheckLogin:'Login....',
      primaryBtnLabel: 'Log in',
      emailRequiredLabel: 'Email required',
      passwordRequiredLabel: 'Password required',
      emailNotValidLabel: 'Valid email required',
      btnLoggedInLabel: 'Close',
      emailPlaceholder: 'Your email',
      email: '',
      password: '',
      checkLabel:'',
      highlightEmailWithError: null,
      highlightPasswordWithError: null,
      isUserCheckLogin: false,
      isFormSuccess: false
    };
  },

  computed: {
    isUserLoggedIn () {
      return this.$store.getters.isUserLoggedIn;
    },
    openModal () {
      if (this.$store.getters.isLoginModalOpen) {
        return true;
      } else {
        return false;
      }
    }
  },

  methods: {
    closeModal () {
      this.$store.commit('showLoginModal', false);
      this.isUserCheckLogin= false;
    },
    checkForm (e) {
      e.preventDefault();

      if (this.email && this.password) {
        this.highlightEmailWithError = false;
        this.highlightPasswordWithError = false;
        this.isFormSuccess = true;
        // this.$store.commit('isUserLoggedIn', this.isFormSuccess);
        this.isUserCheckLogin=true;
        this.checkLabel='Logging...';
        requestToken(this.email, this.password).then(data => {
        // this.loading = false;
        if (data.id != null) {
          // setToken(data);
          this.$store.commit('setUserName', data.username);
          this.$store.commit('setEmail', data.email);
          this.$store.commit('setPhoneNumber', data.phoneNumber);
          this.$store.commit('setAddress', data.address);
          this.$store.commit('setAddress1', data.shippingAddress);
          this.$store.commit('setDOB', data.dob);
          this.$store.commit('setFullName', data.fullName);
          this.$store.commit('setPassword', this.password);
          this.$store.commit('setID', data.id);
          this.isUserCheckLogin=false;
          this.$store.commit('isUserLoggedIn', this.isFormSuccess);
          // this.$router.push('/');
        } else {
          this.checkLabel='Incorrect username or password';
          // this.$store.commit('isUserLoggedIn', this.isFormSuccess);
        }
      });
      }

      if (!this.email) {
        this.highlightEmailWithError = true;

        if (this.email && !isValidEmail(this.email)) {
          this.emailRequiredLabel = this.emailNotValidLabel;
        }
      } else {
        this.highlightEmailWithError = false;
      }

      if (!this.password) {
        this.highlightPasswordWithError = true;
      } else {
        this.highlightPasswordWithError = false;
      }


    },
    checkEmailOnKeyUp (emailValue) {
      if (emailValue && isValidEmail(emailValue)) {
        this.highlightEmailWithError = false;
      } else {
        this.highlightEmailWithError = true;

        if (!isValidEmail(emailValue)) {
          this.emailRequiredLabel = this.emailNotValidLabel;
        }
      }
    },
    checkPasswordOnKeyUp (passwordValue) {
      if (passwordValue) {
        this.highlightPasswordWithError = false;
      } else {
        this.highlightPasswordWithError = true;
      }
    }
  }
};
</script>

<style lang="scss">
.fa-exclamation-circle {
  color: red;
}
.fa-check {
  color: green;
}
</style>


