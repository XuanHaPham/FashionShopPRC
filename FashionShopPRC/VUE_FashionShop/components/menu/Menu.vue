<template>
	<div>
		<div v-if="!isUserLoggedIn"  class="navbar-item">
			<div class="field is-grouped">
				<p class="control">
					<a v-if="!isUserLoggedIn" class="button" @click="showSignupModal">
						<span class="icon">
							<i class="fa fa-user-plus"></i>
						</span>
						<span>{{ signupLabel }}</span>
					</a>
				</p>
				<p class="control">
					<a v-if="!isUserLoggedIn" class="button" @click="showLoginModal">
						<span class="icon">
							<i class="fa fa-user"></i>
						</span>
						<span>{{ loginLabel }}</span>
					</a>
				</p>
			</div>
		</div>
		<div v-if="isUserLoggedIn" class="navbar-item has-dropdown is-hoverable">
			<a class="navbar-item">
			Welcome {{ getUserName }}
			</a>
			<div class="navbar-dropdown is-boxed">
				<nuxt-link class="navbar-item" :to="{ name: 'user-wishlist' }">
					{{ wishlistLabel }}
				</nuxt-link>
				<nuxt-link class="navbar-item" :to="{ name: 'user-profile' }">
					{{ profileLabel }}
				</nuxt-link>
				<nuxt-link class="navbar-item" :to="{ name: 'Feedback-feedback' }">
					{{ feedbackLabel }}
				</nuxt-link>
				<hr class="navbar-divider">
				<a class="navbar-item" @click="logout">
					{{ logoutLabel }}
				</a>
			</div>
		</div>
	</div>
</template>

<script>
export default {
	name: 'VmMenu',
	data () {
		return {
			wishlistLabel: 'Wishlist',
			feedbackLabel: 'Feedback',
			logoutLabel: 'Log out',
			loginLabel: 'Log in',
			signupLabel: 'Sign up',
			profileLabel:'Profile'
		}
	},

	computed: {
		isUserLoggedIn () {
			return this.$store.getters.isUserLoggedIn;
		},
		getUserName () {
			let name = this.$store.getters.getUserName;
			
			if (name === '') {
				return 'user';
			} else {
				return name;
			}
		}
	},

	methods: {
		logout () {
			this.$store.commit('isUserLoggedIn', false);
			this.$store.commit('isUserSignedUp', false);
			this.$store.commit('removeProductsFromFavourite');

			// redirect to homepage
			this.$router.push({ name: 'index' });
		},
		showLoginModal () {
			this.$store.commit('showLoginModal', true);
		},
		showSignupModal () {
			this.$store.commit('showSignupModal', true);
		}
	}
}
</script>

