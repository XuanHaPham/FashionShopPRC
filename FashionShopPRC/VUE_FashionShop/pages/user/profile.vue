<template>
     <section class="hero  is-fullheight">
        <div class="hero-body">
            <div class="container has-text-centered">
                <div class="column is-6 is-offset-3">
                    <h3 class="title">USER PROFILE</h3>
                    <div class="box">
                          <figure class="avatar">
                              <img src="../../static/logo.png">
                          </figure>
           
                        <form>
                            <div class="content">
              <table class="table-profile">
                <tr>
                  <th colspan="1"></th>
                  <th colspan="2"></th>
                </tr>
                <tr>
                  <td>Username:</td>
                  <td>{{ getUserName }}</td>
                </tr>
                <tr>
                  <td>Fullname:</td>
                  <td>{{ getFullname }}</td>
                </tr>
                <tr>
                  <td>Day of birth:</td>
                  <td>{{ getDOB }}</td>
                </tr>
                <tr>
                  <td>Address 1:</td>
                  <td>{{ getAddress }}</td>
                </tr>
                <tr>
                  <td>Address 2:</td>
                  <td>{{ getAddress1 }}</td>
                </tr>
                <tr>
                  <td>Phone:</td>
                  <td>{{ getPhoneNumber }}</td>
                </tr>
                <tr>
                  <td>Email:</td>
                  <td>{{ getEmail }}</td>
                </tr>
              </table>
            </div>
                            <div class="field is-group	ed has-text-centered">
                    <div class="control" style="text-align: center">
                    <a class="button is-primary"  @click="showUpdateModal"><span class="icon">
                    <i class="fa fa-edit"></i>
                         </span>
                  <span>Edit profile</span></a>
                    </div>
                        </div>
                        <div class="field is-group	ed has-text-centered">
                    <div class="control" style="text-align: center">
                    <a class="button is-warning" @click="showPasswordModal"><span class="icon">
                    <i class="fa fa-edit"></i>
                         </span>
                  <span>Change Password</span></a>
                    </div>
                        </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </section>

</template>

<script>
import { METHODS } from 'http';
import { isValidEmail } from '@/assets/validators';


export default {
	name: 'contact',
	data () {
    return {
      pageTitle: 'GET IN TOUCH',  
      emailPlaceholder: 'Your email',
    //   noProductLabel: 'Your wishlist is empty'
    }
  },

computed:{

openModal () {
      if (this.$store.getters.isUpdateModalOpen) {
        return true;
      } else {
        return false;
      }
    },

getUserName () {
			let name = this.$store.getters.getUserName;
			
			if (name === '') {
				return 'user';
			} else {
				return name;
			}
    },
    
getAddress() {
      let name = this.$store.getters.getAddress;
      if (name === '') {
				return 'user';
			} else {
				return name;
			}
},

 getAddress1() {
  let name = this.$store.getters.getAddress1;
  if (name === '') {
				return 'user';
			} else {
				return name;
			}
},

 getPhoneNumber() {
  let name = this.$store.getters.getPhoneNumber;
  if (name === '') {
				return 'user';
			} else {
				return name;
			}
},

 getDOB() {
  let name = this.$store.getters.getDOB;
  if (name === '') {
				return 'user';
			} else {
				return name;
			}
},

 getEmail() {
  let name = this.$store.getters.getEmail;
  if (name === '') {
				return 'user';
			} else {
				return name;
			}
},


 getFullname() {
  let name = this.$store.getters.getFullname;
  if (name === '') {
				return 'user';
			} else {
				return name;
			}
},

    
},

 methods: {
		showUpdateModal () {
			this.$store.commit('showUpdateModal', true);
    },
    
    showPasswordModal () {
			this.$store.commit('showPasswordModal', true);
		},
    checkForm (e) {
      e.preventDefault();



      if (!this.email) {
        this.highlightEmailWithError = true;

        if (this.email && !isValidEmail(this.email)) {
          this.emailRequiredLabel = this.emailNotValidLabel;
        }
      } else {
        this.highlightEmailWithError = false;
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
    }
  }
};

</script>

<style lang="scss" scoped>
  .card {
    margin: 10px;
  }
	p{
		margin: 20px;
		margin-left: 40px; 
		font-weight: bold;
	}
	h3{
		color: palevioletred;
	}
	h4{
		margin: 20px;
	}
  .avatar img {
  padding: 5px;
  background: #fff;
  border-radius: 50%;
  -webkit-box-shadow: 0 2px 3px rgba(10,10,10,.1), 0 0 0 1px rgba(10,10,10,.1);
  box-shadow: 0 2px 3px rgba(10,10,10,.1), 0 0 0 1px rgba(10,10,10,.1);
}
h3{
  color: palevioletred
}
</style>


