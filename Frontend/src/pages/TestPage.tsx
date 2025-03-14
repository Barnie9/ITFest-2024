import { useFormik } from "formik";
import { LoginModel, RegisterModel } from "../utils/models";
import useAuthContext from "../context/AuthContext";

const TestPage = () => {
	const { register, login } = useAuthContext();

	const registerFormik = useFormik({
		initialValues: {
			username: "",
			firstName: "",
			lastName: "",
			email: "",
			password: "",
			confirmPassword: "",
		} as RegisterModel,
		onSubmit: async (values) => {
			console.log(values);

			const response = await register(values);

			if (response) {
				console.log(response);
			} else {
				console.log("Registration successful");
			}
		},
	});

	const loginFormik = useFormik({
		initialValues: {
			usernameOrEmail: "",
			password: "",
		} as LoginModel,
		onSubmit: async (values) => {
			console.log(values);

			const response = await login(values);

			if (response) {
				console.log(response);
			} else {
				console.log("Login successful");
			}
		},
	});

	return (
		<div className="flex w-full flex-col items-center gap-2">
			<h1>Test Page</h1>

			<form
				onSubmit={registerFormik.handleSubmit}
				className="flex w-full flex-col items-center gap-2"
			>
				<label htmlFor="username">Username</label>
				<input
					id="username"
					name="username"
					placeholder="johndoe"
					onChange={registerFormik.handleChange}
					value={registerFormik.values.username}
				/>

				<label htmlFor="firstName">First Name</label>
				<input
					id="firstName"
					name="firstName"
					placeholder="John"
					onChange={registerFormik.handleChange}
					value={registerFormik.values.firstName}
				/>

				<label htmlFor="lastName">Last Name</label>
				<input
					id="lastName"
					name="lastName"
					placeholder="Doe"
					onChange={registerFormik.handleChange}
					value={registerFormik.values.lastName}
				/>

				<label htmlFor="email">Email</label>
				<input
					id="email"
					name="email"
					placeholder="john.doe@gmail.com"
					onChange={registerFormik.handleChange}
					value={registerFormik.values.email}
				/>

				<label htmlFor="password">Password</label>
				<input
					id="password"
					name="password"
					type="password"
					placeholder="password"
					onChange={registerFormik.handleChange}
					value={registerFormik.values.password}
				/>

				<label htmlFor="confirmPassword">Confirm Password</label>
				<input
					id="confirmPassword"
					name="confirmPassword"
					type="password"
					placeholder="password"
					onChange={registerFormik.handleChange}
					value={registerFormik.values.confirmPassword}
				/>

				<button type="submit">Submit</button>
			</form>

			<form
				onSubmit={loginFormik.handleSubmit}
				className="flex w-full flex-col items-center gap-2"
			>
				<label htmlFor="usernameOrEmail">Username or Email</label>
				<input
					id="usernameOrEmail"
					name="usernameOrEmail"
					placeholder="johndoe"
					onChange={loginFormik.handleChange}
					value={loginFormik.values.usernameOrEmail}
				/>

				<label htmlFor="password">Password</label>
				<input
					id="password"
					name="password"
					type="password"
					placeholder="password"
					onChange={loginFormik.handleChange}
					value={loginFormik.values.password}
				/>

				<button type="submit">Submit</button>
			</form>
		</div>
	);
};

export default TestPage;
