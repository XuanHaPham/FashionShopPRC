<template>
  <!-- <div class="section">
    <h3 class="title">{{ pageTitle }}</h3>
    <div class="columns is-centered is-multiline">
      <div class="card column is-one-quarter" v-for="product in productsInWishlist" :key="product.id">
        <VmProductsList :product="product"></VmProductsList>
      </div>
      <div class="section" v-if="productsInWishlist.length === 0">
        <p>{{ noProductLabel }}</p>
      </div>
    </div>
  </div> -->
   <section class="section" >
    <div class="container">
      <div class="section-heading" style="text-align:center"> 
        <h3 class="title is-3" >{{ pageTitle }}</h3>
      </div>
      <br>

      <div class="columns">
        <div class="column is-6 is-offset-3">
         
        <form @submit="checkForm" action="#" method="post">
            <div class="field">
              <label class="label">Message</label>
              <div class="control">
                <textarea class="textarea" placeholder="Textarea" v-model="feedback"
                    @keyup="checkFeedbackOnKeyUp(feedback)"></textarea>
              </div>
                  <span v-if="highlightFeedbackWithError !== null" class="icon is-small is-right">
                    <i :class="[highlightFeedbackWithError ? 'fa fa-exclamation-circle' : 'fa fa-check']"></i>
                  </span>
            </div>

            <div class="field is-grouped has-text-centered">
              <div class="control">
                <button type="submit" class="button is-link is-large"><span class="icon">
                    <i class="fa fa-envelope"></i>
                  </span>
                  <span>Submit</span></button>
              </div>
            </div>

            </form>
        </div>
      </div>

    </div>
  </section>

</template>

<script>
import { base, openapi, methods, routes, setToken, requestToken } from '@/store/index.js'
import { METHODS } from 'http';
export default {
	name: 'feedback',
	data () {
    return {
      pageTitle: 'Feedback Us',
      feedbackPlaceholder: 'Your feedback',
      highlightFeedbackWithError: null,
      feedback:''
    //   noProductLabel: 'Your wishlist is empty'
    }
  },
 
 methods: {
    checkForm (e) {
      e.preventDefault();

if (this.feedback) {
        
        this.highlightFeedbackWithError = false;
        this.isFormSuccess = true;
      openapi(methods.POST, routes.FEEDBACK, {
        "description": this.feedback,
        "email": this.getEmail,
        "accountID": this.getID
        }).then(data => {
        if(data.id !=null){
          
  alert("Feedback Success");
        }
        else 
  alert("Feedback Fail");
        });

      }
      if (!this.feedback) {
        this.highlightFeedbackWithError = true;

        if (this.feedback) {
          this.feedbackRequiredLabel = this.feedbackNotValidLabel;
        }
      } else {
        this.highlightFeedbackWithError = false;
      }
    },
    checkFeedbackOnKeyUp (feedbackValue) {
      if (feedbackValue) {
        this.highlightFeedbackWithError = false;
      } else {
        this.highlightFeedbackWithError = true;

      }
    }
  },
   computed:{
  getEmail() {
  let name = this.$store.getters.getEmail;
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
}
};

</script>

<style lang="scss" scoped>
  .card {
    margin: 10px;
  }
</style>


